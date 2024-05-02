import { Card, CardActionArea, CardContent, Typography } from "@mui/material";
import { FC, ReactElement } from "react";
import { IResource } from "../../../interfaces/resources";
import { useNavigate } from "react-router-dom";

const ResourceCard: FC<IResource> = (props): ReactElement => {
    const navigate = useNavigate();

    return (
        <Card sx={{ maxWidth: 250 }}>
            <CardActionArea onClick={() => navigate(`/resource/${props.id}`)}>
                <div style={{ backgroundColor: props.color, height: 250 }} />
                <CardContent>
                    <Typography noWrap gutterBottom variant="h6" component="div">
                        {props.name}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        {props.year} {props.color}
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card>
    );
}

export default ResourceCard;
