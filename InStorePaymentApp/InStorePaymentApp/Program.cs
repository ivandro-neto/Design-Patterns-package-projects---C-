namespace InStorePaymentApp
{
    public interface IPaymentMethod
    {
        string ProcessPayment(int amount);
        string Refund();
    }

    public class CreditCardPayment : IPaymentMethod
    {
        private int _tempAmount = 0;
        public string ProcessPayment(int amount)
        {
            _tempAmount = amount;
            return $"Paying ${amount} with a Credit card.";
        }

        public string Refund()
        {
            return $"Refunding ${_tempAmount}...";

        }
    }

    public class PayPalPayment : IPaymentMethod
    {
        private int _tempAmount = 0;
        public string ProcessPayment(int amount)
        {
            _tempAmount = amount;
            return $"Paying ${amount} with a Paypal account.";

        }

        public string Refund()
        {
            return $"Refunding ${_tempAmount}...";

        }
    }

    public class BankTransferPayment : IPaymentMethod
    {
        private int _tempAmount = 0;
        public string ProcessPayment(int amount)
        {
            _tempAmount = amount;
            return $"Paying ${amount} with a Debit card.";
        }

        public string Refund()
        {
            return $"Refunding ${_tempAmount}...";

        }
    }

    public class CreditCardPaymentAdapter : IPaymentMethod
    {
        private CreditCardPayment _payment;
        public CreditCardPaymentAdapter(CreditCardPayment creditCard)
        {
            _payment = creditCard;
        }
        public string ProcessPayment(int amount)
        {
            return _payment.ProcessPayment(amount);
        }
        public string Refund()
        {
            return _payment.Refund();
        }
    }

    public class PaypalPaymentAdapter : IPaymentMethod
    {
        private PayPalPayment _payment;
        public PaypalPaymentAdapter(PayPalPayment account)
        {
            _payment = account;
        }
        public string ProcessPayment(int amount)
        {
            return _payment.ProcessPayment(amount);
        }
        public string Refund()
        {
            return _payment.Refund();
        }
    }

    public class BankTransferPaymentAdapter : IPaymentMethod
    {
        private BankTransferPayment _payment;
        public BankTransferPaymentAdapter(BankTransferPayment creditCard)
        {
            _payment = creditCard;
        }
        public string ProcessPayment(int amount)
        {
            return _payment.ProcessPayment(amount);
        }
        public string Refund()
        {
            return _payment.Refund();
        }
    }

    public class AdapterFactory
    {
        private static AdapterFactory _instance;

        private AdapterFactory() { }

        public static AdapterFactory GetInstance()
        {
            if (_instance == null)
            {
                 
                _instance =  new AdapterFactory();

            }
            return _instance;
        }
        public IPaymentMethod paymentMethod(string method)
        {
            switch (method.ToLower())
            {
                case "paypal": return new PaypalPaymentAdapter(new PayPalPayment());
                case "credit": return new CreditCardPaymentAdapter(new CreditCardPayment());
                case "debit": return new BankTransferPaymentAdapter(new BankTransferPayment());
                default:
                    throw new ArgumentException("Invalid payment method.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AdapterFactory factory = AdapterFactory.GetInstance();
            IPaymentMethod adapter = null;
            Console.WriteLine("Select the payment method : Debit | Credit | Paypal");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                adapter = factory.paymentMethod(input);
                Console.WriteLine(adapter.ProcessPayment(500000));
                Console.WriteLine(adapter.Refund());
            }
            else
            {
                Console.WriteLine("Cannot load the adapter.");
            }

            Console.ReadKey();
        }
    }
}
