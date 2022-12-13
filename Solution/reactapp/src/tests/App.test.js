import { render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import App from '../App';

test('fe_d1_testcase2', () => {
  const { container, getByTestId, debug } = render(<MemoryRouter><App /></MemoryRouter>);
  expect(getByTestId("navigation")).toBeTruthy();
  expect(container).toBeInTheDocument();
});


