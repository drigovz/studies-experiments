import { Link } from "react-router-dom";

interface LinkProps {
    to: string;
    title?: string;
}

const CustomLink: React.FC<LinkProps> = ({ to, title, children }) => {
    return (
        <Link to={to} title={title}>
            {children}
        </Link>
    );
}

export default CustomLink;