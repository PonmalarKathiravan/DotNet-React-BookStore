import axios from 'axios';
import React, { useContext, useEffect, useState } from 'react';
import AuthContext from '../Authentication/AuthContext';
import _ from "lodash";

const Cart = (props) => {

    const [state, setState] = useState({
        cartItems : []
    });

    const [refresh, setRefresh] = useState(true);

    const authContent = useContext(AuthContext);

    const credentials = authContent.state.auth;

    const removeItem = productId => {
        axios.delete(`https://8080-effddfdaeebcfacbdcbaeaaadcacbbdccadeba.examlyiopb.examly.io/Cart/user/deleteCart/${productId}`)
        .then(res => {
            setRefresh(prevState => !prevState);
        })
    }

    const addOrder =  () => {
        
        const tempCartItems = _.cloneDeep(state.cartItems)
        
        tempCartItems.map(item => {
            item.orderId = item.sno+'';
            delete item.cartId;
            return item;
        }) 
        console.log('cart',tempCartItems);
        axios.post(`https://8080-effddfdaeebcfacbdcbaeaaadcacbbdccadeba.examlyiopb.examly.io/user/addorder`, tempCartItems )
        .then(res => {
             return;
        })
        axios.delete(`https://8080-effddfdaeebcfacbdcbaeaaadcacbbdccadeba.examlyiopb.examly.io/Cart/user/deleteallcartitems`)
                .then(res => {
                    authContent.history.push("/orders");
                    setRefresh(prevState => !prevState)
                })
    }

    useEffect(() => {
        axios.get(`https://8080-effddfdaeebcfacbdcbaeaaadcacbbdccadeba.examlyiopb.examly.io/Cart/user/${credentials.username}/cartitems`)
        .then(res => {
            if(res.data) {
                setState({
                    cartItems : res.data
                })
            }
        })
    });

    return (
        <div className="container mt-5">
            <div className="row">
                <div className="col-md-12">
                    <table className="table table-borderless" style={{border : 'none'}}>
                        <thead className="bg-info">
                        <tr className="text-center">
                            <th scope="col">Book Name</th>
                            <th scope="col">Price</th>
                            <th scope="col">Quantity</th>
                            <th scope="col">Delete</th>
                        </tr>
                        </thead>
                        <tbody>
                            {state.cartItems.length === 0 && <h4 className="text-center px-2 py-4">No Items in cart</h4>}
                            {
                                state.cartItems.map(cart => {
                                    return (
                                        <tr >
                                            <td className="text-center">{cart.productName}</td>
                                            <td className="text-center">{cart.price}</td>
                                            <td className="text-center">{cart.quantity}</td>
                                            <td style={{marginRight : "10px"}} onClick={() => removeItem(cart.sno)} className="text-center"><a className="btn btn-danger text-white"><i className="fas fa-trash"></i></a></td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </table>
                    <button data-testid="placeorder" className="btn btn-primary mt-3" onClick={addOrder}>Place order</button>
                    <div style={{height : "30px"}}></div>
                </div>
            </div>
        </div>
     );
}
 
export default Cart;