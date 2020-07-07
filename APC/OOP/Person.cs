using System;
namespace OOP
{
    class Person
    {
        public string FullName {get;set;}
        private string pinCode;

        public decimal MathScore {get;set;}
        public decimal ITScore {get;set;}
        private decimal averageScore => (MathScore*3 + ITScore*2)/5;;

        public decimal AverageScore{
            get => averageScore;
        }


        //Case 1
        public string GetPinCode(){
            return $"{pinCode.Substring(0, pinCode.Length - 3)}XXX";
        }

        public void SetPinCode(string newPinCode){
            pinCode = newPinCode;
        }

        //case 2

        // public string PinCode
        // {
        //     get{
        //         return $"{pinCode.Substring(0, pinCode.Length - 3)}XXX";
        //     }
        //     set{
        //         pinCode  = value;
        //     }
        // }
        //Case 3
        public string PinCode{
            get {
                if("CA" == "CA"){
                    return  $"{pinCode.Substring(0, pinCode.Length - 3)}XXX";
                }
                else{
                    return $"Khong biet";
                };
            }
            set => pinCode = value;
        }
        public override string ToString() {
            return "";
        }
    }
}