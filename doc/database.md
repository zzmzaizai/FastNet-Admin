# ���ݱ����

#### SysTenant `�⻧��`

* Id `���`
* Name `�⻧������˾��`
* Domains `������` - ����������ż��
* StartDate `��ʼʱ��`
* EndDate `����ʱ��`
* Tel  `�绰`
* Email  `����`
* Contact  `��ϵ��`
* Remark `��ע`
* IsDefault `Ĭ��վ��`
* Status `״̬` - �⻧״̬ö��


#### SysRelation `ϵͳ��ϵ��`

* Id `���`
* SourceId `Դ���`
* TargetId `Ŀ����`
* RelationType `��ϵ����` - �û���ɫ���û���֯����ɫ��֯����ɫ�˵����ͻ���API
* ExtraData `��������`


#### SysUser `�û���`

* Id `�û����`
* UserName `�û���`
* Password `����`
* Secret `��Կ` - �û�������μ���
* Email `����`
* NickName `�ǳ�`
* FullName `ȫ��`
* Tel  `�绰`
* Avatar  `ͷ��`
* Sex `�Ա�` - �ֵ���
* Title `ְλ` - �ֵ���
* IsSuperAdmin `�Ƿ񳬼�����Ա`
* Status `״̬` - �û�״̬ö��
* LoginIP  `��¼IP`
* LoginDate `��¼ʱ��`



#### SysOrganization `��֯���ű�`

* Id `��֯���`
* Name `����`
* ParentId `�ϼ���֯���`
* Leader `������`
* Tel  `�绰`
* Email `����`
* Remark `��ע`
* Order `����`
* Status `״̬` - ��֯����״̬ö��


#### SysRole `��ɫ��`

* Id `��ɫ���`
* Name `����`
* Remark `��ע`
* Status `״̬` - ��ɫ״̬ö��


#### SysMenu `�˵���`

* Id `��ɫ���`
* Name `����`
* ParentId `�ϼ��˵����`
* Router `ҳ��·��`
* Path `ҳ����Դ·��`
* Actions `ӵ�ж�������` - �������ö��֮�䶺�ŷָ�
* Order `����`
* Status `״̬` - �˵�״̬ö��

#### SysApiResource `Api��Դ��`

* Id `API���`
* Name `����`
* Group `��������` - ���ֵ䶨����Դ����
* Router `API·��`
* Path `API��Դ·��`
* Method `���󷽷�`
* Summary `ժҪ`
* Remark `��ע`
* Order `����`
* Status `״̬` - API״̬ö��

#### SysClientApp `�ͻ���Ӧ�ñ�`

* Id `�ͻ��˱��`
* Name `����`
* ClientCode `�ͻ��˱���`
* SecretKey `˽Կ`
* Tel  `�绰`
* Email `����`
* Contact  `��ϵ��`
* Remark `��ע`
* Status `״̬` - �ͻ���״̬ö��





#### SysDictType `�ֵ����ͱ�`

* Id `���`
* DictTypeName `�ֵ���������`
* DictType `�ֵ�����`
* Order `����`

#### SysDictData `�ֵ����ݱ�`


* Id `���`
* DictType `�ֵ����ͱ��`
* DictName `�ֵ�����`
* DictValue `�ֵ�����`
* Order `����`
* Status `״̬` - �ֵ�״̬ö��

#### SysConfig `ϵͳ���ñ�`

* Id `���`
* Lable `��������`
* Key `����Key`
* Value `����ֵ`



## ��һ������Ƶı�

#### SysTask `�������ñ�`

#### SysTaskLog `������־��`

#### SysOperLog `������־��`

#### SysLoginLog `��¼��־��`