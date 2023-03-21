interface ImageProps {
    logo: string;
    alternatedText?: string;
    title?: string;
}

const Image: React.FC<ImageProps> = ({ logo, alternatedText, title }) => {
    return (
        <img src={logo} alt={alternatedText} title={title} />
    );
}

export default Image;