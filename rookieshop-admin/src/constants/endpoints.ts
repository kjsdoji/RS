const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',
    
    brand: 'api/Products/paging',
    brandId: (id: number | string): string => `api/Products/${id}`,

};

export default Endpoints;
