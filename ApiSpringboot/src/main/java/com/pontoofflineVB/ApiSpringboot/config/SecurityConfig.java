package com.pontoofflineVB.ApiSpringboot.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.web.SecurityFilterChain;

@Configuration
public class SecurityConfig {

    /**
     * Security configuration for local/dev testing.
     *
     * This permits access to API endpoints and the marcação static page so you can
     * test without a login page. For production, remove/adjust this class.
     */
    @Bean
    public SecurityFilterChain filterChain(HttpSecurity http) throws Exception {
        http
            .csrf(csrf -> csrf.disable())
            // allow browser access to H2 console if present
            .headers(headers -> headers.frameOptions(frame -> frame.disable()))
            .authorizeHttpRequests(auth -> auth
                // DEV: allow everything for testing local UI and endpoints
                .requestMatchers("/**").permitAll()
            )
            // disable the default login form for dev convenience
            .formLogin(form -> form.disable())
            .httpBasic(basic -> basic.disable());

        return http.build();
    }
}
