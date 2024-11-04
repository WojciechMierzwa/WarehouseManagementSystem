using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;
using System.IO;

namespace ConsoleInventoryManagerV2
{
    internal class InvoicePdfGenerator
    {
        public static void GenerateInvoicePdf(InvoiceData invoiceData, string outputPath)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pl-PL");
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Element(container => Header(container, invoiceData));
                    page.Content().Element(container =>
                    {
                        container.Column(column =>
                        {
                            column.Spacing(10);
                            column.Item().Element(x => OrderDetailsSection(x, invoiceData));
                            column.Item().Element(x => SellerSection(x));
                            column.Item().Element(x => CustomerSection(x, invoiceData));
                            column.Item().Element(x => ProductListSection(x, invoiceData));
                            column.Item().Element(x => TotalAmountSection(x, invoiceData));
                        });
                    });
                    page.Footer().AlignCenter().Text("Dziękujemy za zakup!").FontSize(10).Italic();
                });
            });

            document.GeneratePdf(outputPath);
            System.Console.WriteLine($"Invoice PDF generated at {outputPath}");
        }

        private static void Header(IContainer container, InvoiceData invoiceData)
        {
            container.Row(row =>
            {
                row.RelativeColumn().Text($"Faktura nr {invoiceData.InvoiceId}").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
            });
        }

        private static void SellerSection(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeColumn().Stack(stack =>
                {
                    stack.Item().Text("Sprzedawca:").Bold();
                    stack.Item().Text("Dobre Polskie Magazyny - Wojciech Mierzwa").Bold();
                    stack.Item().Text("82-300 Elbląg Polska");
                    stack.Item().Text("Address: Słoneczna 18 A");
                    stack.Item().Text("NIP : 2085820858");
                });
            });
        }

        private static void CustomerSection(IContainer container, InvoiceData invoiceData)
        {
            container.Row(row =>
            {
                row.RelativeColumn().Stack(stack =>
                {
                    stack.Item().Text($"Nabywca:").Bold();
                    stack.Item().Text($"{invoiceData.CustomerName}").Bold();
                    stack.Item().Text($"{invoiceData.CustomerPostalCode} {invoiceData.CustomerCity}, {invoiceData.CustomerCountry}");
                    stack.Item().Text($"Address: {invoiceData.CustomerAddressRow1}, {invoiceData.CustomerAddressRow2}");
                    stack.Item().Text($"NIP : {invoiceData.CustomerNip}");
                });
            });
        }

        private static void OrderDetailsSection(IContainer container, InvoiceData invoiceData)
        {
            container.Row(row =>
            {
                row.RelativeColumn().Stack(stack =>
                {
                    stack.Item().Text($"Wystawiono dnia: {invoiceData.InvoiceDate:dd-MM-yyyy}");
                });
            });
        }

        private static void ProductListSection(IContainer container, InvoiceData invoiceData)
        {
            container.Table(table =>
            {
                // Definicja kolumn
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(30);   // Ilość
                    columns.RelativeColumn(100);      // Produkt
                    columns.ConstantColumn(100);   // Cena netto
                    columns.ConstantColumn(100);   // Wartość netto
                    columns.ConstantColumn(60);    // VAT
                    columns.ConstantColumn(100);    // Wartość brutto
                });

                // Nagłówek tabeli
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("Ilość");
                    header.Cell().Element(CellStyle).Text("Produkt");
                    header.Cell().Element(CellStyle).AlignRight().Text("Cena netto");
                    header.Cell().Element(CellStyle).AlignRight().Text("Wartość netto");
                    header.Cell().Element(CellStyle).AlignRight().Text("VAT");
                    header.Cell().Element(CellStyle).AlignRight().Text("Wartość brutto");
                });

                // Wiersze z danymi produktów
                foreach (var product in invoiceData.Products)
                {
                    table.Cell().Element(CellStyle).Text(product.Quantity.ToString());
                    table.Cell().Element(CellStyle).Text(product.ProductName);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{product.UnitPrice:C}");                // Cena netto
                    table.Cell().Element(CellStyle).AlignRight().Text($"{product.TotalPrice:C}");              // Wartość netto
                    table.Cell().Element(CellStyle).AlignRight().Text($"{(int)(product.VatRate)}%");                     
                    table.Cell().Element(CellStyle).AlignRight().Text($"{product.TotalPrice + product.TotalPrice * product.VatRate/100:C}"); // Wartość brutto
                }
            });
        }

        private static void TotalAmountSection(IContainer container, InvoiceData invoiceData)
        {
            container.AlignRight().Text($"Razem: {invoiceData.TotalAmount:C}").FontSize(14).Bold();
        }

        private static IContainer CellStyle(IContainer container)
        {
            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
        }
    }
}
