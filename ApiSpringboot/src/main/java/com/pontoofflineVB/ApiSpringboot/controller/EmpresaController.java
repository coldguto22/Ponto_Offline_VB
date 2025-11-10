package com.pontoofflineVB.ApiSpringboot.controller;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.pontoofflineVB.ApiSpringboot.Model.Empresa;
import com.pontoofflineVB.ApiSpringboot.repository.EmpresaRepository;

@RestController
@RequestMapping("/api/empresas")
public class EmpresaController {

    @Autowired
    private EmpresaRepository empresaRepository;

    @GetMapping
    public List<Empresa> listar() {
        return empresaRepository.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Empresa> buscar(@PathVariable Long id) {
        Optional<Empresa> opt = empresaRepository.findById(id);
        return opt.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PostMapping
    public ResponseEntity<Empresa> criar(@RequestBody Empresa empresa) {
        Empresa salvo = empresaRepository.save(empresa);
        return new ResponseEntity<>(salvo, HttpStatus.CREATED);
    }

    @PutMapping("/{id}")
    public ResponseEntity<Empresa> atualizar(@PathVariable Long id, @RequestBody Empresa empresa) {
        return empresaRepository.findById(id).map(existing -> {
            // atualizar campos básicos
            existing.setRazaoSocial(empresa.getRazaoSocial());
            existing.setNomeFantasia(empresa.getNomeFantasia());
            existing.setCnpj(empresa.getCnpj());
            existing.setInscEstadual(empresa.getInscEstadual());
            existing.setEndereco(empresa.getEndereco());
            existing.setTelefone(empresa.getTelefone());
            existing.setEmail(empresa.getEmail());
            existing.setLogo(empresa.getLogo());
            Empresa updated = empresaRepository.save(existing);
            return ResponseEntity.ok(updated);
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletar(@PathVariable Long id) {
        return empresaRepository.findById(id).map(existing -> {
            empresaRepository.delete(existing);
            return ResponseEntity.noContent().<Void>build();
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }
}
