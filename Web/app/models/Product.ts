export interface IProduct {
    productID: number;
    CategoryID: number;
    Discounted: boolean;
    productName: string;
    quantityPerUnit?: string;
    ReorderLevel: number;
    SupplierID: number;
    UnitsInStock: number;
    UnitsInOrder: number;
    
}