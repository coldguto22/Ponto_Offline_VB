package com.pontoofflineVB.ApiSpringboot.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class MarcacaoController {

    @GetMapping("/marcacao")
    public String marcacao() {
        return "marcacao";
    }
}
