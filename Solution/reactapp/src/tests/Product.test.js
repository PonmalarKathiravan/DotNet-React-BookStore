import { cleanup, render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import AuthContext from '../Components/Authentication/AuthContext';
import Product from "../Components/Products/Product/Product";

const renderWithContext = (value) => {

    const testProps = {
        edit : jest.fn(),
        delete : jest.fn(),
        addcart : jest.fn(),
        price : "23",
        description : 'Test Description',
        productName : 'Test Product',
        url : 'test url',
        quantity : '200'
    }

    return  render(
        <MemoryRouter>
            <AuthContext.Provider value={value}>
                <Product {...testProps} />
            </AuthContext.Provider>
        </MemoryRouter>
    )
}

const adminVal = {
    state : {
        auth : {
            username : 'test@gmail.com',
            authenticated : true,
            role : 'ADMIN'
        }
    }         
}

const userVal = {
    state : {
        auth : {
            username : 'test@gmail.com',
            authenticated : false,
            role : 'USER'
        }
    }         
}

afterEach(cleanup);


test('fe_d1_testcase9', () => {
  const { container, debug } = renderWithContext(userVal);
  expect(container).toBeInTheDocument();
//   debug();
  expect(screen.getByText('200 items left in stock')).toBeTruthy();
  expect(screen.getByText('Test Description')).toBeTruthy();
  expect(screen.getByText('Test Product')).toBeTruthy();
  expect(screen.getByText('₹ 23')).toBeTruthy();
  
});

test('fe_d1_testcase10', () => {
    const { container, debug } = renderWithContext(userVal);
    expect(screen.getByText('Cart')).toBeTruthy();
    expect(screen.queryByText('Edit')).toBeFalsy();
    expect(screen.queryByText('Delete')).toBeFalsy();
})

test('fe_d1_testcase11', () => {
    const { container, debug } = renderWithContext(adminVal);
    expect(screen.queryByText('Edit')).toBeTruthy();
    expect(screen.queryByText('Delete')).toBeTruthy();
    expect(screen.getByText('Cart')).toBeTruthy();
})


