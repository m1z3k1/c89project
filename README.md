# c89project
***
##�d�v�t�H���_

1.Assets�t�H���_�F�g�p������̂͑S�Ă��̉��ɁB
2.Assets/json�t�H���_�F�f�[�^���Ǘ�����json�t�@�C���̒u����
3.Assets/Plugins�t�H���_�F�O���t�@�C��
4.Assets/prefabs�t�H���_�Fprefab���܂Ƃ߂�t�H���_
5.Assets/script�t�H���_�F.cs�t�@�C�����܂Ƃ߂�t�H���_
***
## weapon

����(�e��)�̓X�e�[�^�X��json�A�����weapon.cs���p������class��p���č쐬���܂��B�܂��A���햼=class��=prefavb���Ƃ���悤�ɁB
###JSON
  json�ł̃X�e�[�^�X�ݒ�͈ȉ��̗v�́B
    "���햼":{
    "attack":"int�^ �U����",
    "other parameter":"�����ɕK�v�Ȓl",
    "next":[{
    "name":"������̕��햼",
    "exp":"int�^ �����ɕK�v�Ȍo���l"
    }]
    },
  
###����
  ����͐��쎞��StartAttack()���Ă΂�܂��B���̂Ƃ��A�C�g->�e��->�e�ۂƂ����e�q�֌W�ɂȂ��Ă���̂ŁA
�K�v������Ίe��f�[�^�𗘗p���A�K�v���������@�Ɋ֌W�Ȃ������������Ȃ�e�q�֌W���������Ă��������B
  �ڐG�����ۂɌĂ΂��function��Attack�ł��B�����ǋL���Ȃ���΁A���������ΏۂɃ_���[�W��^���邾���ł��B
  
  JSON��͂�MiniJSON���g�p���Ă��܂��BJSON�ŉ�͂����f�[�^�͐����^��long�ŁA�����^��double�ŃL���X�g���Ȃ��Ǝg�p�ł��܂���B
  
  MiniJSON(github):<https://gist.github.com/darktable/1411710>
