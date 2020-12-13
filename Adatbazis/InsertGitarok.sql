create or replace procedure sp_Insertgitarok(
    p_sorozatszam in gitarok.sorozatszam%TYPE,
    p_tipus in gitarok.tipus%TYPE,
    p_gyarto    in gyartok.nev%TYPE,
    p_gyartas_datum in gitarok.gyartas_datum%TYPE,
    p_balkezes in gitarok.balkezes%TYPE,
    p_erintok_szama in gitarok.erintok_szama%TYPE,
    p_hangszedok in gitarok.hangszedok%TYPE,
    p_out_rowcnt out int
)
authid definer
as
    v_check_sorozatszam int;
    v_gyarto_id int;
begin
    p_out_rowcnt := 0;
    v_gyarto_id := sf_getGyartoId(p_gyarto);
    if v_gyarto_id is null then
        sp_insertGyartok(p_gyarto);
        v_gyarto_id := sf_getGyartoId(p_gyarto);
    end if;
    v_check_sorozatszam := sf_checksorozatszam(p_sorozatszam);
    if v_check_sorozatszam = 1 then
        insert into gitarok
            (sorozatszam, tipus, gyarto_id, gyartas_datum, balkezes, erintok_szama, hangszedok)
        values
            (p_sorozatszam, p_tipus, v_gyarto_id, p_gyartas_datum, p_balkezes, p_erintok_szama, p_hangszedok);
        p_out_rowcnt := SQL%rowcount;
        commit;
    end if;
end;