create or replace procedure sp_insertGyartok
(
    p_nev in gyartok.nev%type
)
authid definer
as
    v_id int;
begin
    select max(id) into v_id from gyartok;
	
	if v_id is null then		
		v_id := 0;
	end if;
	
    v_id := v_id + 1;
    
    insert into gyartok(id, nev)
    values(v_id, p_nev);
end sp_insertGyartok;