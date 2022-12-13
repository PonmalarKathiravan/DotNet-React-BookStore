import { cleanup, render, screen } from '@testing-library/react';
import { MemoryRouter, useHistory } from 'react-router-dom';
import AddProduct from '../Components/AddProduct/AddProduct';
import AuthContext from '../Components/Authentication/AuthContext';
import EditProduct from '../Components/EditProduct/EditProduct';


describe('Testing AddProduct Component', () => {

    afterEach(cleanup);

    const mockfn = jest.fn();

    const userRole = {
        state : {
            auth : {
                role: 'USER',
                authenticated : true,
                username : 'test@gmail.com'
            }
        }, 
        history : {
            location : {
                state : {
                    state : {
                        productName : 'Test product',
                        description : 'Test Description',
                        quantity : '2',
                        price : '24',
                        imageUrl : 'Test URL'
                    }
                }
            },
            push : mockfn,
            goBack : mockfn,
            replace : mockfn,
            go : mockfn
        },
        notify : mockfn
    }

    const renderWithContext = (value) => {
        return  render(
            <MemoryRouter>
                <AuthContext.Provider value={value}>
                    <EditProduct />
                </AuthContext.Provider>
            </MemoryRouter>
        )
    }

    test('fe_d1_testcase4' , () => {
        const { container, debug } = renderWithContext(userRole);

        expect(screen.queryByTestId('editproduct')).toBeTruthy();
        expect(screen.queryByTestId('imageUrl')).toBeTruthy();
        expect(screen.queryByTestId('quantity')).toBeTruthy();
        expect(screen.queryByTestId('price')).toBeTruthy();
        expect(screen.queryByTestId('description')).toBeTruthy();
        expect(screen.queryByTestId('productName')).toBeTruthy();
    })

    test('fe_d1_testcase5' , () => {
        const { container, debug } = renderWithContext(userRole);

        expect(screen.queryByTestId('imageUrl').value).toBe('Test URL');
        expect(screen.queryByTestId('quantity').value).toBe('2');
        expect(screen.queryByTestId('price').value).toBe('24');
        expect(screen.queryByTestId('description').value).toBe('Test Description');
        expect(screen.queryByTestId('productName').value).toBe('Test product');
    })


})