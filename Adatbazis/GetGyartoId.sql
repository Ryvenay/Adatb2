create or replace function sf_GetGyartoId
(
    p_nev in gyartok.nev%type
)
return int
deterministic
as
    temp int;
    temp_cnt int;
begin
    select count(*) into temp_cnt FROM gyartok where nev = p_nev;

	if temp_cnt = 0 THEN 
		RETURN null;
	ELSE
		SELECT id into temp from gyartok where nev = p_nev;
	END IF;

    RETURN temp;
end sf_GetGyartoId;