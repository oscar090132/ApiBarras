using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using BarcodeLib.Barcode;

namespace ApiBarras.Models
{
    public class CodigoBarras
    {
        public string NumeroConvenio { get; set; }
        public string NumeroFactura { get; set; }
        public long ValorPagar { get; set; }
        public string FechaLimite { get; set; }
        
        public string Codigo
        {
            get
            {
                return "(415)" + NumeroConvenio + "(8020)" + NumeroFactura.PadLeft(12, '0') + "(3900)" + ValorPagar.ToString().PadLeft(10, '0') + "(96)" +FechaLimite;
            }
        }
        public Stream ImagenCodigo
        {
            get
            {
                BarcodeLib.Barcode.Linear barcode = new BarcodeLib.Barcode.Linear();
                barcode.Type = BarcodeType.EAN128;
                barcode.Data = Codigo;
                barcode.UOM = UnitOfMeasure.PIXEL;
                barcode.BarWidth = 1;
                barcode.BarHeight = 40;
                barcode.ImageWidth = 380;
                barcode.LeftMargin = 0;
                barcode.RightMargin = 0;
                barcode.TopMargin = 0;
                barcode.BottomMargin = 0;
                barcode.ShowText = true;

                barcode.TextFont = new Font("Tahoma", 7, FontStyle.Regular);
                return new MemoryStream(barcode.drawBarcodeAsBytes());

            }
        }
    }
}