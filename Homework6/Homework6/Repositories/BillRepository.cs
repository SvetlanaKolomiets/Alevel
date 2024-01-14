using Homework6.Entities;

namespace Homework6.Repositories
{
	public class BillRepository
	{
        private BillEntity[] _bills = new BillEntity[100];
        private int _billCount = 0;
        public BillRepository()
		{

        }

        public string AddBill(string product, double price)
        {
            var bill = new BillEntity()
            {
                Id = Guid.NewGuid().ToString(),
                ShopName = "Svetlana shop",
                Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                Products = product,
                TotalPrice = price
            };

            _bills[_billCount] = bill;
            _billCount++;

            return bill.Id;
        }

        public BillEntity GetBill(string id)
        {
            foreach (var bill in _bills)
            {
                if (bill.Id == id)
                {
                    return bill;
                }
                    
            }

            return null;
        }
    }
}
