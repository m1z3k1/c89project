# c89project
***
## weapon

����(�e��)�̓X�e�[�^�X��json�A�����weapon.cs���p������class��p���č쐬���܂��B�܂��A���햼=class��=prefavb���Ƃ���悤�ɁB
###JSON
  json�ł̃X�e�[�^�X�ݒ�͈ȉ��̗v�́B
    "���햼":{
    "param":{
    "attack":"int�^ �U����",
    "other parameter":"�����ɕK�v�Ȓl"
    },
    "next":[{
    "name":"������̕��햼",
    "exp":"int�^ �����ɕK�v�Ȍo���l"
    }]
    },
  
###����
  ����͐��쎞��Start�̂��ƁAStartAttack()���Ă΂�܂��B���̂Ƃ��A�C�g->�e��->�e�ۂƂ����e�q�֌W�ɂȂ��Ă���̂ŁA
�K�v������Ίe��f�[�^�𗘗p���A�K�v���������@�Ɋ֌W�Ȃ������������Ȃ�e�q�֌W���������Ă��������B
  �ڐG�����ۂɌĂ΂��function��Attack�ł��B�����ǋL���Ȃ���΁A���������ΏۂɃ_���[�W��^���邾���ł��B
