using System.ComponentModel;

namespace FreeCourse.Web.Models.Orders
{
    public class CheckoutInfoInput
    {
        [DisplayName("İl")]
        public string Province { get; set; }
        [DisplayName("İlçe")]
        public string District { get; set; }
        [DisplayName("Cadde")]
        public string Street { get; set; }
        [DisplayName("Posta Kodu")]
        public string ZipCode { get; set; }
        [DisplayName("Adres")]
        public string Line { get; set; }
        [DisplayName("Kart Ad Soyad")]
        public string CardName { get; set; }
        [DisplayName("Kart Numarası")]
        public string CardNumber { get; set; }
        [DisplayName("Son Kullanma Tarih(ay/yıl) ")]
        public string Expiration { get; set; }
        [DisplayName("CVV/CVC2")]
        public string CVV { get; set; }
    }
}
