import React, { useState } from "react";

const StateExemple: React.FC = () => {
    const [counter, setCounter] = useState(1);
    
    function incrementCounter() {
        setCounter(counter + 1);
        console.log(counter);
    }

    return (
        <>
            <button onClick={incrementCounter}>Increment</button>
            <p>{counter}</p>
        </>
    );
}

export default StateExemple;