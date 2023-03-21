import React, { useCallback, useEffect, useState } from 'react';
import api from '../services/api';
import Image from './Image';

interface Item {
    id: number,
    title: string,
    image_url: string,
}

const List: React.FC = () => {
    // get itens from back-end
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
    }, [setSelectedItems]);

    return (
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
    );
}

export default List;