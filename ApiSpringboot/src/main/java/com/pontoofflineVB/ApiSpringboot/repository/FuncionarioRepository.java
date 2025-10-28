package com.pontoofflineVB.ApiSpringboot.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.pontoofflineVB.ApiSpringboot.Model.Funcionario;

public interface FuncionarioRepository extends JpaRepository<Funcionario, Long> {

    List<Funcionario> findByEmpresaId(Long empresaId);
}
