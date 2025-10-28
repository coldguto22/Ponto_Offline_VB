package com.pontoofflineVB.ApiSpringboot.repository;

import java.time.LocalDate;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.pontoofflineVB.ApiSpringboot.Model.RegistroPonto;

public interface RegistroPontoRepository extends JpaRepository<RegistroPonto, Long> {

    List<RegistroPonto> findByFuncionarioId(Long funcionarioId);

    List<RegistroPonto> findByData(LocalDate data);
}
