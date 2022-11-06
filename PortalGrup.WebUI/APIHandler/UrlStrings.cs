namespace PortalGrup.WebUI.APIHandler
{
    public static class UrlStrings
    {
        //Category
        public static string GetAllCategory = "Category/GetAllCategory";
        public static string AddCategory = "Category/AddCategory";
        public static string RemoveCategory = "Category/RemoveCategory";
        public static string UpdateCategory = "Category/UpdateCategory";
        public static string GetByCategoryId = "Category/GetByCategoryId";
        public static string ChangeStatus = "Category/ChangeStatus";
        //Customer
        public static string GetAllCustomer = "Customer/GetAllCustomer";
        public static string AddNewCustomer = "Customer/AddNewCustomer";
        public static string GetByCustomerId = "Customer/GetByCustomerId";
        public static string UpdateCustomer = "Customer/UpdateCustomer";
        public static string ChangeCustomerStatus = "Customer/ChangeCustomerStatus";
        //Address
        public static string CustomerAddress = "Address/GetCustomerAddress";
        public static string GetAddress = "Address/GetAddress";
        public static string AddNewAddres = "Address/AddNewAddres";
        public static string UpdateAddres = "Address/UpdateAddres";
        public static string GetByAddressId = "Address/GetByAddressId";
        public static string ChangeAdressStatus = "Address/ChangeAdressStatus";
        //Products
        public static string GetAllProduct = "Product/GetAllProduct";
        public static string GetByProductId = "Product/GetByProductId";
        public static string AddNewProduct = "Product/AddNewProduct";
        public static string UpdateProduct = "Product/UpdateProduct";
        public static string ChangeProductStatus = "Product/ChangeProductStatus";
        //Basket
        public static string GetBasketByCustomerId = "Basket/GetBasketByCustomerId";
        public static string AddToBasket = "Basket/AddToBasket";
        public static string UpdateBasket = "Basket/UpdateBasket";
        public static string BasketClear = "Basket/BasketClear";
        public static string RemoveBasket = "Basket/RemoveBasket";
        public static string GetAllBasket = "Basket/GetAllBasket";
        public static string GetBasket = "Basket/GetBasket";

        //Order
        public static string CreateOrder = "Order/CreateOrder";
        public static string GetAllOrder = "Order/GetAllOrder";
        public static string OrderCancel = "Order/OrderCancel";
    }
}
