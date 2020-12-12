create or replace procedure spInsert_gitarok(
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
    v_check_rendszam int;
    v_gyarto_id int;
begin
    p_out_rowcnt := 0;
    v_gyarto_id := sf_getGyartoId(p_gyarto);
    if v_gyarto_id is null then
        sp_insertGyartok(p_gyarto);
        v_gyarto_id := sf_getGyartoId(p_gyarto);
    end if;
    v_check_rendszam := sf_check_rendszam(p_rendszam);
    if v_check_rendszam = 1 then
        insert into autok
            (rendszam, alvazszam, gyarto_id, tipus, uzemanyag, evjarat, gyorsulas, meghajtas)
        values
            (p_rendszam, p_alvazszam, v_gyarto_id, p_tipus, p_uzemanyag, p_evjarat, p_gyorsulas, p_meghajtas);
        p_out_rowcnt := SQL%rowcount;
        commit;
    end if;
end spInsert_autok;