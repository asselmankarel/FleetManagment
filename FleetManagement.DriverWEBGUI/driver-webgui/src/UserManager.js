import { UserManager} from 'oidc-client';

const config = {
    authority: "https://localhost:5001",
    client_id: "fleetmanagement-driver-webgui",
    redirect_uri: "https://localhost:3000/callback",
    response_type: "code",
    scope:"openid profile fleetmanagement-read-api fleetmanagement-write-api",
    post_logout_redirect_uri : "https://localhost:3000/",
};

const userManager = new UserManager(config);

export default userManager;