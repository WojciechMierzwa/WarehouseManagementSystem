using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;

namespace ConsoleInventoryManagerV2
{
    internal class InvoicePdfGenerator
    {
        public static void GenerateInvoicePdf(InvoiceData invoiceData, string outputPath)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Element(Header);
                    page.Content().Element(container =>
                    {
                        container.Column(column =>
                        {
                            column.Spacing(10);

                            column.Item().Element(x => CustomerSection(x, invoiceData));
                            column.Item().Element(x => OrderDetailsSection(x, invoiceData));
                            column.Item().Element(x => ProductListSection(x, invoiceData));
                            column.Item().Element(x => TotalAmountSection(x, invoiceData));
                        });
                    });
                    page.Footer().AlignCenter().Text("Thank you for your business!").FontSize(10).Italic();
                });
            });

            document.GeneratePdf(outputPath);
            System.Console.WriteLine($"Invoice PDF generated at {outputPath}");
        }

        private static void Header(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeColumn().Text("INVOICE").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
            });
        }

        private static void CustomerSection(IContainer container, InvoiceData invoiceData)
        {
            container.Row(row =>
            {
                row.RelativeColumn().Stack(stack =>
                {
                    stack.Item().Text($"Customer: {invoiceData.CustomerName}").Bold();
                    stack.Item().Text($"Email: {invoiceData.CustomerEmail}");
                    stack.Item().Text($"Phone: {invoiceData.CustomerPhone}");
                    stack.Item().Text($"Address: {invoiceData.CustomerAddressRow1}, {invoiceData.CustomerAddressRow2}");
                    stack.Item().Text($"{invoiceData.CustomerPostalCode} {invoiceData.CustomerCity}, {invoiceData.CustomerCountry}");
                });
            });
        }

        private static void OrderDetailsSection(IContainer container, InvoiceData invoiceData)
        {
            container.Row(row =>
            {
                row.RelativeColumn().Stack(stack =>
                {
                    stack.Item().Text($"Invoice ID: {invoiceData.InvoiceId}");
                    stack.Item().Text($"Date: {invoiceData.InvoiceDate:dd-MM-yyyy}");
                });
            });
        }

        private static void ProductListSection(IContainer container, InvoiceData invoiceData)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(50);
                    columns.RelativeColumn();
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(100);
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("Qty");
                    header.Cell().Element(CellStyle).Text("Product");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit Price");
                    header.Cell().Element(CellStyle).AlignRight().Text("VAT Rate");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total Price");
                });

                foreach (var product in invoiceData.Products)
                {
                    table.Cell().Element(CellStyle).Text(product.Quantity);
                    table.Cell().Element(CellStyle).Text(product.ProductName);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{product.UnitPrice:C}");
                    table.Cell().Element(CellStyle).AlignRight().Text($"{product.VatRate:P}");
                    table.Cell().Element(CellStyle).AlignRight().Text($"{product.TotalPrice:C}");
                }
            });
        }

        private static void TotalAmountSection(IContainer container, InvoiceData invoiceData)
        {
            container.AlignRight().Text($"Total Amount: {invoiceData.TotalAmount:C}").FontSize(14).Bold();
        }

        private static IContainer CellStyle(IContainer container)
        {
            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
        }
    }
}
