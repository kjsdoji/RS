import { User, UserManager, UserManagerSettings } from "oidc-client";

import { CallBackEndpoints, UrlBackEnd } from "../constants/oidc-configs";

const oidcSettings: UserManagerSettings = {
  authority: UrlBackEnd,
  client_id: "admin",
  redirect_uri: CallBackEndpoints.redirect_uri,
  post_logout_redirect_uri: CallBackEndpoints.post_logout_redirect_uri,
  response_type: "id_token token",
  scope: "rookieshop.api openid profile offline_access",
  automaticSilentRenew: true,
  includeIdTokenInSilentRenew: true,
};

class AuthService {
  public userManager: UserManager;

  constructor() {
    this.userManager = new UserManager(oidcSettings);
  }

  public getUserAsync(): Promise<User | null> {
    return this.userManager.getUser();
  }

  public loginAsync(): Promise<void> {
    return this.userManager.signinRedirect({
        state: location.hash,
    });
  }

  public completeLoginAsync(url: string): Promise<User | undefined> {
    return this.userManager.signinRedirectCallback(url);
  }
  
  public renewTokenAsync(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logoutAsync(): Promise<void> {
    return this.userManager.signoutRedirect();
  }

  public async completeLogoutAsync(url: string): Promise<void> {
    await this.userManager.signoutRedirectCallback(url);
  }
}

export default new AuthService();