package com.pontoofflineVB.ApiSpringboot.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.pontoofflineVB.ApiSpringboot.Model.Empresa;

public interface EmpresaRepository extends JpaRepository<Empresa, Long> {
    // você pode adicionar métodos customizados, se quiser
}
