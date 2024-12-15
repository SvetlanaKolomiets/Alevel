// pages
import Home from "./pages/Home";
import About from "./pages/About";
import Products from "./pages/Resources";
import User from "./pages/Users";

import {FC} from "react";
import Resource from "./pages/Resource";
import UserForm from "./pages/Home/components/UserForm";
import Login from "./pages/Login";
import Registration from "./pages/Registration";

interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        component: Home
    },
    {
        key: 'about-route',
        title: 'About',
        path: '/about',
        enabled: true,
        component: About
    },
    {
        key: 'resources-route',
        title: 'Resources',
        path: '/resources',
        enabled: true,
        component: Products
    },{
        key: 'resource-route',
        title: 'Resource',
        path: '/resource/:id',
        enabled: false,
        component: Resource
    },
    {
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: false,
        component: User
    },
    {
        key: 'login-route',
        title: 'Login',
        path: '/login',
        enabled: true,
        component: Login
    },
    {
        key: 'registration-route',
        title: 'Registration',
        path: '/registration',
        enabled: true,
        component: Registration
    }
]