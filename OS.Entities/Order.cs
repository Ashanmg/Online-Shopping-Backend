using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int AccountUserId { get; set; }
        public int BillingAddressId { get; set; }
        public string OrderStatus { get; set; }
        public int PickupInStore { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethodSystemName { get; set; }
        public string AccountUserCurrencyCode { get; set; }
        public decimal CurrencyRate { get; set; }
        public decimal OrderSubTotal { get; set; }
        public decimal OrderSubTotalDiscount { get; set; }
        public decimal PaymentMethodAdditionalFee { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal RefundableAmmount { get; set; }
        public int AllowStoringCreditCardNumber { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public int MaskedCreditCardNumber { get; set; }
        public int CardCvv2 { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public string AuthenticationTransactionId { get; set; }
        public string AuthenticationTransactionCode { get; set; }
        public string AuthenticationTransactionResult { get; set; }
        public string CaptureTransactionId { get; set; }
        public string CaptureTransactionResult { get; set; }
        public string SubscriptionTransactionId { get; set; }
        public DateTime PaidDateUTC { get; set; }
        public DateTime CreatedOnUTC { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<AccountUser> Users { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

        public Order()
        {
            Stores = new List<Store>();
            Users = new List<AccountUser>();
            Addresses = new List<Address>();
        }

    }
}
