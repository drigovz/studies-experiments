import React from "react";
import './styles.scss';
import { FiLogIn } from 'react-icons/fi';
import logo from '../../assets/logo.svg';
import Header from "../../Components/Header";
import Image from "../../Components/Image";
import CustomLink from "../../Components/CustomLink";

const Home: React.FC = () => {
    return (
        <div id="page-home">
            <div className="content">
                <Header title="Selective collection and recycling in general">
                    <Image logo={logo} title="Recycling" alternatedText="Recycling" />
                </Header>

                <main>
                    <h1>Selective collection and recycling in general</h1>
                    <p>Recycling of various materials, such as paper, plastic, metal, cells and batteries, etc.</p>

                    <CustomLink to="/create-location" title="Recycling">
                        <span>
                            <FiLogIn />
                        </span>
                        <strong>Register a new collection site</strong>
                    </CustomLink>
                </main>
            </div>
        </div>
    );
}

export default Home;