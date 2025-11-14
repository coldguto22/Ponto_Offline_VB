package com.pontoofflineVB.ApiSpringboot.config;

import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@Configuration
public class CorsConfig implements WebMvcConfigurer {

    @Override
    public void addCorsMappings(CorsRegistry registry) {
        registry.addMapping("/api/**")
                .allowedOrigins("http://localhost:*", "http://127.0.0.1:*", "http://*")
                .allowedMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                .allowedHeaders("*")
                .allowCredentials(true)
                .maxAge(3600);

        // Para ambiente de produção, substitua as URLs acima pelas suas
        // registry.addMapping("/api/**")
        //     .allowedOrigins("https://seu-dominio.com")
        //     .allowedMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
        //     .allowedHeaders("*")
        //     .allowCredentials(true)
        //     .maxAge(3600);
    }
}
