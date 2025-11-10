package com.pontoofflineVB.ApiSpringboot.controller;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.pontoofflineVB.ApiSpringboot.Model.RegistroPonto;
import com.pontoofflineVB.ApiSpringboot.repository.RegistroPontoRepository;

@RestController
@RequestMapping("/api/registros")
public class RegistroPontoController {

    @Autowired
    private RegistroPontoRepository registroRepository;

    @GetMapping
    public List<RegistroPonto> listar(@RequestParam(name = "funcionarioId", required = false) Long funcionarioId,
            @RequestParam(name = "data", required = false) @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate data) {
        if (funcionarioId != null) {
            return registroRepository.findByFuncionarioId(funcionarioId);
        }
        if (data != null) {
            return registroRepository.findByData(data);
        }
        return registroRepository.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<RegistroPonto> buscar(@PathVariable Long id) {
        Optional<RegistroPonto> opt = registroRepository.findById(id);
        return opt.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PostMapping
    public ResponseEntity<RegistroPonto> criar(@RequestBody RegistroPonto registro) {
        RegistroPonto salvo = registroRepository.save(registro);
        return new ResponseEntity<>(salvo, HttpStatus.CREATED);
    }

    @PutMapping("/{id}")
    public ResponseEntity<RegistroPonto> atualizar(@PathVariable Long id, @RequestBody RegistroPonto registro) {
        return registroRepository.findById(id).map(existing -> {
            existing.setData(registro.getData());
            existing.setHora(registro.getHora());
            existing.setTipo(registro.getTipo());
            existing.setFuncionario(registro.getFuncionario());
            RegistroPonto updated = registroRepository.save(existing);
            return ResponseEntity.ok(updated);
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletar(@PathVariable Long id) {
        return registroRepository.findById(id).map(existing -> {
            registroRepository.delete(existing);
            return ResponseEntity.noContent().<Void>build();
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }
}
