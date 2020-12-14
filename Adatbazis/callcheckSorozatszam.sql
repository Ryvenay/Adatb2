set serveroutput on;
declare
    v_call_sorozartszam int;
    v_sorozatszam gitarok.sorozatszam%TYPE := 'N900007';
begin
    v_call_sorozartszam := sf_checksorozatszam(v_sorozatszam);
    IF v_call_sorozartszam = 1 THEN
        DBMS_OUTPUT.PUT_LINE('A sorozatszam helyes: '||v_sorozatszam);
    ELSE 
        DBMS_OUTPUT.PUT_LINE('A sorozatszam helytelen: '||v_sorozatszam);    
    END IF;
end;