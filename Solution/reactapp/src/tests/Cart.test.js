import { cleanup, fireEvent, render, screen, wait, waitFor } from "@testing-library/react"
import { MemoryRouter } from "react-router-dom";
import AuthContext from "../Components/Authentication/AuthContext";
import Cart from "../Components/Cart/Cart";
import React, { useState } from "react";

describe('Test Cart Component', () => {
    

    afterEach(() => {
        cleanup();
    });

    

    const authValue = {
        state : {
            auth : {
                username : 'test@gmail.com',
                authenticated : false,
                role : 'ADMIN'
            }
        }
    }
    
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
                    <Cart  />
                </AuthContext.Provider>
            </MemoryRouter>) 
        )
    }

    test('fe_d1_testcase3', () => {
        const { container, debug } = renderWithContext(authValue);

        expect(screen.findByTestId('placeorder')).toBeTruthy();
        expect(screen.getByText('No Items in cart')).toBeTruthy();

        debug();      

    })

})