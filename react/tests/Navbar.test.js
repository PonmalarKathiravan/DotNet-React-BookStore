import { cleanup, getByAltText, getByTestId, getByText, render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import AuthContext from '../Components/Authentication/AuthContext';
import Navbar from '../Components/Navbar/Navbar';



describe('Testing ADMIN', () => {

    afterEach(cleanup);

    const renderWithContext = (value) => {
        return (
            render(<MemoryRouter>
                <AuthContext.Provider value={value}>
                    <Navbar  />
                </AuthContext.Provider>
            </MemoryRouter>) 
        )
    }

    

    test('Render admin functionality', () => {

        const stateVal = {
            state : {
                auth : {
                    username : 'test@gmail.com',
                    authenticated : true,
                    role : 'ADMIN'
                }
            }         
        }

        const { container, getByTestId, debug } = renderWithContext(stateVal); 
        expect(container).toBeInTheDocument();
        expect(screen.getByText('Logout')).toBeTruthy();
        expect(getByTestId('addproduct')).toBeTruthy();
        expect(getByTestId('orders')).toBeTruthy();
    })

    test('Render user functionality', () => {

        const stateVal = {
            state : {
                auth : {
                    username : 'test@gmail.com',
                    authenticated : true,
                    role : 'USER'
                }
            }         
        }
        const { getByTestId, debug } = renderWithContext(stateVal);

        expect(screen.getByText('Logout')).toBeTruthy();
        expect(screen.queryByTestId('addproduct')).toBeNull();
        expect(getByTestId('orders')).toBeTruthy();
        cleanup();
    })

    test('fe_d1_testcase7', () => {

        const stateVal = {
            state : {
                auth : {
                    username : '',
                    authenticated : false,
                    role : ''
                }
            }         
        }

        const { getByTestId, debug } = renderWithContext(stateVal);

        // expect(screen.getByText('logout')).toBe('Login')
        expect(screen.getByText('Login')).toBeTruthy();

        const addProduct = screen.queryByTestId('addproduct')
        const orders = screen.queryByTestId('orders');


        expect(addProduct).not.toBeInTheDocument();
        expect(orders).not.toBeInTheDocument();;
    })


})