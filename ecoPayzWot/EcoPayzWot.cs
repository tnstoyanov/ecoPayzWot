using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ecoPayzWot
{
    class EcoPayzWot
    {
        private static void Main(string[] args)
        {
            string PaymentPageID = "1148";
            string MerchantAccountNumber = "112743";
            string CustomerIdAtMerchant = "7654321";
            string TxID = "000000001";
            //string TxID = DateTime.Now.ToString("hhmmddMMyy");
            string Amount = "1.00";
            string Currency = "USD";
            string MerchantFreeText = "Fortissio Demo USD Deposit";
            string MerchantPassword = "Df3r6W5b3Dx6";
            string OnSuccessUrl = "https://tnstoyanov.wixsite.com/payment-response/success";
            string OnFailureUrl = "https://tnstoyanov.wixsite.com/payment-response/failed";
            string TransferUrl = "https://db46a064326442f75c6172ae6772049a.m.pipedream.net";
            string CancellationUrl = "https://tnstoyanov.wixsite.com/payment-response/cancel";
            string CallbackUrl = "https://db46a064326442f75c6172ae6772049a.m.pipedream.net";
            string FirstName = "Tony";
            string LastName = "Stoyanov";
            string DateOfBirth = "1950-01-01";


            string checksum = Hash(
                PaymentPageID
                + MerchantAccountNumber
                + CustomerIdAtMerchant
                + TxID
                + Amount
                + Currency
                + MerchantFreeText
                + OnSuccessUrl
                + OnFailureUrl
                + TransferUrl
                + CancellationUrl
                + CallbackUrl
                + FirstName
                + LastName
                + DateOfBirth
                + MerchantPassword
                );

            Console.WriteLine(
                "https://secure.test.ecopayz.com/PrivateArea/WithdrawOnlineTransfer.aspx?"
                + "PaymentPageID="
                + PaymentPageID
                + "&MerchantAccountNumber="
                + MerchantAccountNumber
                + "&CustomerIdAtMerchant="
                + CustomerIdAtMerchant
                + "&TxID="
                + TxID
                + "&Amount="
                + Amount
                + "&Currency="
                + Currency
                + "&MerchantFreeText="
                + MerchantFreeText
                + "&OnSuccessUrl="
                + OnSuccessUrl
                + "&OnFailureUrl="
                + OnFailureUrl
                + "&TransferUrl="
                + TransferUrl
                + "&CancellationUrl="
                + CancellationUrl
                + "&CallbackUrl="
                + CallbackUrl
                + "&FirstName="
                + FirstName
                + "&LastName="
                + LastName
                + "&DateOfBirth="
                + DateOfBirth
                + "&Checksum="
                + checksum
                );

            Console.ReadLine();

            //Use MD5 for ecoPayz' checksum
            string Hash(string input)
            {
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    //x2 for lowercase
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
