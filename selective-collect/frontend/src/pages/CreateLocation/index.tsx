import React, { ChangeEvent, FormEvent, useCallback, useEffect, useState } from 'react';
import { FiArrowLeft } from 'react-icons/fi';
import logo from '../../assets/logo.svg';
import CustomLink from '../../Components/CustomLink';
import Image from '../../Components/Image';
import { Map, TileLayer, Marker } from 'react-leaflet';
import { LeafletMouseEvent } from 'leaflet';
import './style.scss';
import api from '../../services/api';
import {useHistory} from 'react-router-dom';

interface Item {
    id: number,
    title: string,
    image_url: string,
}

const CreateLocation: React.FC = () => {
    // Set map marker position
    const [selectedPosition, setSelectedPosition] = useState<[number, number]>([0, 0]);

    const handleClickMap = useCallback((event: LeafletMouseEvent): void => {
        console.log(event);

        setSelectedPosition([
            event.latlng.lat,
            event.latlng.lng
        ]);
    }, []);

    // get list itens with images from back-end
    const [items, setItems] = useState<Item[]>([]);

    useEffect(() => {
        api.get('items').then(response => {
            console.log(response.data);
            setItems(response.data);
        }).catch(error => {
            console.log(error);
        });
    }, []);

    // get data from list
    const [selectedItems, setSelectedItems] = useState<number[]>([]);

    const handleSelectItem = useCallback((id: number): void => {
        const alreadySelected = selectedItems.findIndex(idOnState => idOnState === id);
        if (alreadySelected >= 0) {
            const filteredItens = selectedItems.filter(item => item !== id);
            setSelectedItems(filteredItens);
        } else {
            setSelectedItems([...selectedItems, id]);
        }
    }, [selectedItems]);

    // input data from form
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        whatsapp: '',
        city: '',
        uf: '',
    });
 
    const handleInputChange = useCallback((event: ChangeEvent<HTMLInputElement>): void => {
        console.log(event.target.name, event.target.value);

        const { name, value } = event.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    }, [formData]);

    const history = useHistory();

    // send data for back-end
    const handleSubmit = useCallback(async (event: FormEvent): Promise<void> => {
        event.preventDefault();

        const { city, email, name, uf, whatsapp } = formData;
        const [latitude, longitude] = selectedPosition;
        const items = setSelectedItems;

        const data = {
            city,
            email,
            name,
            uf,
            whatsapp,
            latitude,
            longitude,
            items,
        };

        await api.post('locations', data).then(res => {
            console.log(res.data);
        }).catch(err => {
            console.log(err);
        });

        alert('Location created successfull!');

        // redirect to home page 
        history.push('/');

    }, [formData, selectedPosition, history]);

    return (
        <div id="page-create-location">
            <div className="content">
                <header>
                    <Image logo={logo} alternatedText="Coleta Seletiva" />
                    <CustomLink to="/">
                        <FiArrowLeft />
                        Voltar para home
                    </CustomLink>
                </header>

                <form onSubmit={handleSubmit}>
                    <h1>Cadastro do <br /> local de coleta</h1>

                    <fieldset>
                        <legend>
                            <h2>Dados</h2>
                        </legend>

                        <div className="field">
                            <label htmlFor="name">Nome da entidade</label>
                            <input
                                type="text"
                                name="name"
                                id="name"
                                onChange={handleInputChange}
                            />
                        </div>
                        <div className="field-group">
                            <div className="field">
                                <label htmlFor="email">E-mail</label>
                                <input
                                    type="email"
                                    name="email"
                                    id="email"
                                    onChange={handleInputChange}
                                />
                            </div>
                            <div className="field">
                                <label htmlFor="whatsapp">Whatsapp</label>
                                <input
                                    type="text"
                                    name="whatsapp"
                                    id="whatsapp"
                                    onChange={handleInputChange}
                                />
                            </div>
                        </div>
                    </fieldset>

                    <fieldset>
                        <legend>
                            <h2>Endereço</h2>
                            <span>Marque o endereço no mapa</span>
                        </legend>
                        <Map center={[-23.0003709, -43.365895]} zoom={14}
                            onclick={handleClickMap}
                            onChange={handleInputChange} >
                            <TileLayer
                                attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                            />
                            <Marker position={selectedPosition} />
                        </Map>

                        <div className="field-group">
                            <div className="field">
                                <label htmlFor="city">Cidade</label>
                                <input
                                    type="text"
                                    name="city"
                                    id="city"
                                    onChange={handleInputChange}
                                />
                            </div>
                            <div className="field">
                                <label htmlFor="uf">Estado</label>
                                <input
                                    type="text"
                                    name="uf"
                                    id="uf"
                                    onChange={handleInputChange}
                                />
                            </div>
                        </div>
                    </fieldset>

                    <fieldset>
                        <legend>
                            <h2>Ítens coletados</h2>
                            <span>Você pode marcar um ou mais ítens</span>
                        </legend>
                    </fieldset>

                    <ul className='items-grid'>

                        {items.map(item => (
                            <li
                                key={item.id}
                                onClick={() => handleSelectItem(item.id)}
                                className={selectedItems.includes(item.id) ? 'selected' : ''}
                            >
                                <Image logo={item.image_url} alternatedText={item.title} title={item.title} />
                            </li>
                        ))}

                    </ul>

                    <button type="submit">
                        Cadastrar local de coleta
                    </button>
                </form>
            </div>
        </div>
    );
}

export default CreateLocation;