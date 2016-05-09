export interface IProduct {
    ProducID: number;
    CategoryID: number;
    Discounted: boolean;
    ProductName: string;
    QuantityPerUnit?: string;
    ReorderLevel: number;
    SupplierID: number;
    UnitsInStock: number;
    UnitsInOrder: number;
    
}