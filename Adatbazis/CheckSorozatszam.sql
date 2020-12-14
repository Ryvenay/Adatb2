create or replace function sf_checksorozatszam
(
    p_sorozatszam in gitarok.sorozatszam%TYPE
)
return int
deterministic
as
    v_char char(1);
    v_i int;
begin
    if p_sorozatszam is null then
        return 0;
    end if;

    if length(trim(p_sorozatszam)) < 4 then
        return 0;
    end if;
    if length(trim(p_sorozatszam)) > 10 then
        return 0;
    end if;


    v_i := 1;
    while v_i < length(trim(p_sorozatszam)) loop
        v_char := substr(p_sorozatszam, v_i, 1);
        exit when not (ascii('A') <= ascii(v_char) and ascii(v_char) <= ascii('Z'));
        v_i := v_i+1;
    end loop;

    if v_i = length(trim(p_sorozatszam)) then
        return 0;
    end if;

    while v_i < length(trim(p_sorozatszam)) loop
        v_char := substr(p_sorozatszam, v_i, 1);
        if not (ascii('0') <= ascii(v_char) and ascii(v_char) <= ascii('9')) then
            return 0;            
        end if;
        v_i := v_i + 1;
    end loop;
    return 1;
end;