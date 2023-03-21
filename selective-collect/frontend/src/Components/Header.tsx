interface HeaderProps {
    title: string;
}

const Header: React.FC<HeaderProps> = ({ title, children }) => {
    return (
        <header title={title}>{children}</header>
    );
}

export default Header;