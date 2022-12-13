import { cleanup, fireEvent, render, screen, wait, waitFor } from "@testing-library/react"
import { MemoryRouter } from "react-router-dom";
import AuthContext from "../Components/Authentication/AuthContext";
import React, { useState } from "react";
import Orders from "../Components/Orders/Orders";

describe('Test Login Component', () => {
    

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
                    <Orders  />
                </AuthContext.Provider>
            </MemoryRouter>) 
        )
    }

    test('fe_d1_testcase8', () => {
        const { container, debug } = renderWithContext(authValue);

        expect(container).toBeTruthy();
        expect(screen.getByText('No Orders to Display')).toBeTruthy();

        debug();      

    })

})