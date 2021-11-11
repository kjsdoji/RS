const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',
    
    brand: 'api/brand',
    brandId: (id: number | string): string => `api/brand/${id}`,
    category: 'api/category',
    categoryId: (id: number | string): string => `api/category/${id}`,

};

export default Endpoints;
