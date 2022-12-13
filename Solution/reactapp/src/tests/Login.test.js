import { cleanup, fireEvent, render, screen } from "@testing-library/react"
import { MemoryRouter } from "react-router-dom";
import AuthContext from "../Components/Authentication/AuthContext";
import Login from "../Components/Login/Login";

describe('Test Login Component', () => {
    
    afterEach(cleanup);

    const stateContextVal = {
        state : {
            auth : {
                role : 'ADMIN',
                authenticated : false,
                username : 'test@gmail.com'
            }
        }
    }

    const renderWithContext = (value) => {
        return (
            render(<MemoryRouter>
                <AuthContext.Provider value={value}>
                    <Login  />
                </AuthContext.Provider>
            </MemoryRouter>) 
        )
    }

    test('fe_d1_testcase6', () => {
        const { container, debug } = renderWithContext(stateContextVal);
        
        const inputEl = screen.getByTestId('email');
        const passwordEl = screen.getByTestId('password');
        const loginEl = screen.getByTestId('login');
        const signupEl = screen.getByTestId('signup');

        expect(inputEl).toBeTruthy();
        expect(passwordEl).toBeTruthy();
        expect(loginEl).toBeTruthy();
        expect(signupEl).toBeTruthy();

        fireEvent.change(inputEl, {target : {value : 'test email'}})
        expect(inputEl.value).toBe('test email');

        fireEvent.change(inputEl, {target : {value : 'test password'}})
        expect(inputEl.value).toBe('test password');

    })

})