import {Card, CardActionArea, CardContent, CardMedia, Typography} from "@mui/material"
import {FC, ReactElement} from "react";
import {IUser} from "../../../interfaces/users";
import {useNavigate} from "react-router-dom";
import UserStore from "../../Users/UserStore";

const UserCard: FC<IUser> = (props): ReactElement => {

    const navigate = useNavigate()

    const handleCardClick = () => {
        if (props.id) {
            const userId: string = props.id;
            UserStore.getUserById(userId);
            navigate(`/user/${userId}`);
        }
    };

     return (
        <Card sx={{ maxWidth: 250 }}>
            <CardActionArea onClick={handleCardClick}>
                <CardMedia
                    component="img"
                    height="250"
                    image={props.avatar}
                    alt={props.email}
                />
                <CardContent>
                    <Typography noWrap gutterBottom variant="h6" component="div">
                        {props.email}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        {props.first_name} {props.last_name}
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card>
    )
}

export default UserCard