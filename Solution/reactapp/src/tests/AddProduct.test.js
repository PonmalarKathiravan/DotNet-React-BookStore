import { cleanup, render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import AddProduct from '../Components/AddProduct/AddProduct';
import AuthContext from '../Components/Authentication/AuthContext';

describe('Testing AddProduct Component', () => {

    afterEach(cleanup);

    const renderWithContext = (value) => {
    
        return  render(
            <MemoryRouter>
                <AuthContext.Provider value={value}>
                    <AddProduct />
                </AuthContext.Provider>
            </MemoryRouter>
        )
    }

    test('fe_d1_testcase1' , () => {
        const { container, debug } = renderWithContext({});

        expect(screen.queryByTestId('addproduct')).toBeTruthy();
        expect(screen.queryByTestId('imageUrl')).toBeTruthy();
        expect(screen.queryByTestId('quantity')).toBeTruthy();
        expect(screen.queryByTestId('price')).toBeTruthy();
        expect(screen.queryByTestId('description')).toBeTruthy();
        expect(screen.queryByTestId('productName')).toBeTruthy();
    })

})