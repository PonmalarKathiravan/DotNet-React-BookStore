import { cleanup, fireEvent, render, screen } from "@testing-library/react"
import { MemoryRouter } from "react-router-dom";
import AuthContext from "../Components/Authentication/AuthContext";
import Signup from "../Components/Signup/Signup";

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
                    <Signup  />
                </AuthContext.Provider>
            </MemoryRouter>) 
        )
    }

    test('fe_d1_testcase12', () => {
        const { container, debug } = renderWithContext(stateContextVal);
        
        const emailEl = screen.getByTestId('email');
        const passwordEl = screen.getByTestId('password');
        const usernameEl = screen.getByTestId('username');
        const confirmpasswordEl = screen.getByTestId('confirmpassword');
        const mobileNumberEl = screen.getByTestId('mobileNumber');
        const roleEl = screen.getByTestId('role');
        const signupEl = screen.getByTestId('signup');

        expect(roleEl).toBeTruthy();
        expect(passwordEl).toBeTruthy();
        expect(usernameEl).toBeTruthy();
        expect(confirmpasswordEl).toBeTruthy();
        expect(mobileNumberEl).toBeTruthy();
        expect(emailEl).toBeTruthy();
        expect(signupEl).toBeTruthy();

        fireEvent.change(emailEl, {target : {value : 'test email'}})
        expect(emailEl.value).toBe('test email');

        fireEvent.change(passwordEl, {target : {value : 'test password'}})
        expect(passwordEl.value).toBe('test password');

        fireEvent.change(confirmpasswordEl, {target : {value : 'test password'}})
        expect(confirmpasswordEl.value).toBe('test password');

        fireEvent.change(usernameEl, {target : {value : 'test username'}})
        expect(usernameEl.value).toBe('test username');

        fireEvent.change(mobileNumberEl, {target : {value : '1234567890'}})
        expect(mobileNumberEl.value).toBe('1234567890');

        fireEvent.change(roleEl, {target : {value : 'ADMIN'}})
        expect(roleEl.value).toBe('ADMIN');

    })

})