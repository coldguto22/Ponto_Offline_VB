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
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.pontoofflineVB.ApiSpringboot.Model.Funcionario;
import com.pontoofflineVB.ApiSpringboot.dto.LoginRequest;
import com.pontoofflineVB.ApiSpringboot.repository.FuncionarioRepository;

@RestController
@RequestMapping("/api/funcionarios")
public class FuncionarioController {

    @Autowired
    private FuncionarioRepository funcionarioRepository;

    @GetMapping
    public List<Funcionario> listar(@RequestParam(name = "empresaId", required = false) Long empresaId,
            @RequestParam(name = "cpf", required = false) String cpf) {
        if (cpf != null && !cpf.isEmpty()) {
            return funcionarioRepository.findByCPF(cpf);
        }
        if (empresaId != null) {
            return funcionarioRepository.findByEmpresaId(empresaId);
        }
        return funcionarioRepository.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Funcionario> buscar(@PathVariable Long id) {
        Optional<Funcionario> opt = funcionarioRepository.findById(id);
        return opt.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PostMapping("/login")
    public ResponseEntity<Funcionario> login(@RequestBody LoginRequest request) {
        List<Funcionario> funcionarios = funcionarioRepository.findByCPF(request.getCpf());
        if (funcionarios.isEmpty()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }
        return ResponseEntity.ok(funcionarios.get(0));
    }

    @PostMapping
    public ResponseEntity<Funcionario> criar(@RequestBody Funcionario funcionario) {
        Funcionario salvo = funcionarioRepository.save(funcionario);
        return new ResponseEntity<>(salvo, HttpStatus.CREATED);
    }

    @PutMapping("/{id}")
    public ResponseEntity<Funcionario> atualizar(@PathVariable Long id, @RequestBody Funcionario funcionario) {
        return funcionarioRepository.findById(id).map(existing -> {
            existing.setNome(funcionario.getNome());
            existing.setCPF(funcionario.getCPF());
            existing.setCargo(funcionario.getCargo());
            existing.setDataAdmissao(funcionario.getDataAdmissao());
            existing.setPis(funcionario.getPis());
            existing.setFolha(funcionario.getFolha());
            existing.setHorario(funcionario.getHorario());
            existing.setDataDemissao(funcionario.getDataDemissao());
            existing.setFoto(funcionario.getFoto());
            existing.setDataNascimento(funcionario.getDataNascimento());
            existing.setAdmin(funcionario.getAdmin());
            existing.setEmpresa(funcionario.getEmpresa());
            Funcionario updated = funcionarioRepository.save(existing);
            return ResponseEntity.ok(updated);
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletar(@PathVariable Long id) {
        return funcionarioRepository.findById(id).map(existing -> {
            funcionarioRepository.delete(existing);
            return ResponseEntity.noContent().<Void>build();
        }).orElseGet(() -> ResponseEntity.notFound().build());
    }
}
