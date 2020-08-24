# log4ntest
log4ntest
test .adf
ad 
typora-copy-images-to: notepic
typora-root-url: notepic


DCG 笔记

环境的搭建

代码，业务学习资料

\hghrnd-fs\hgh01\AS_CA_Video_Monitor_F\01 研发部\02 VCN开发部\01 项目组文件夹\03 VCN设备接入组\03 组内培训

编译环境

http://3ms.huawei.com/hi/group/2028923/wiki_5805202.html 

x86编译服务器地址：100.107.221.34 root/grape@123 

arm编译服务器地址：10.116.190.151 root/grape@123 

DCG项目组 编译服务器100.99.99.20   root/Huawei@123 

C50 开发环境

编译

在iSource上选择项目主干分支，创建自己的分支，注意源分支选择



在编译服务器上的个人目录下

1. cloneC50主干

git clone 

1. 切换到自己的远程分支
       git checkout -b newBranch  origin/newBranch
2. 软连接

在/usr1/home/ywx948591/VCN_R19C30

    [root@shaphicprc38250 ~]# cd /usr1/home/ywx948591
    [root@shaphicprc38250 ywx948591]# ls
    VCN_R19  VCN_R19C30
    [root@shaphicprc38250 ywx948591]# cd VCN_R19C30
    [root@shaphicprc38250 VCN_R19C30]# ln -s /usr1/home/workspace/IVS_R19C50/workcode/binary/
    [root@shaphicprc38250 VCN_R19C30]# ln -s /usr1/home/workspace/IVS_R19C50/workcode/platform/
    [root@shaphicprc38250 VCN_R19C30]# ln -s /usr1/home/workspace/IVS_R19C50/workcode/vendor/
    [root@shaphicprc38250 VCN_R19C30]# ln -s /usr1/home/FD/
    [root@shaphicprc38250 VCN_R19C30]# ls -il
    total 24
    10830677 lrwxrwxrwx.  1 root root   48 Jun 29 09:15 binary -> /usr1/home/workspace/IVS_R19C50/workcode/binary/
    10969780 drwx------.  8 root root 4096 Jun 28 20:35 common
    10830669 -rw-------.  1 root root 5384 Jun 28 20:35 downcode.xml
    10830686 lrwxrwxrwx.  1 root root   13 Jun 29 11:38 FD -> /usr1/home/FD
    10830678 lrwxrwxrwx.  1 root root   50 Jun 29 09:15 platform -> /usr1/home/workspace/IVS_R19C50/workcode/platform/
    10830656 -rw-------.  1 root root 3584 Jun 28 20:35 README.md
    14156650 drwx------.  6 root root 4096 Jun 28 20:35 test
    15975233 drwx------. 11 root root 4096 Jun 28 20:35 VCN
    10830679 lrwxrwxrwx.  1 root root   48 Jun 29 09:15 vendor -> /usr1/home/workspace/IVS_R19C50/workcode/vendor/
    [root@shaphicprc38250 VCN_R19C30]# rm -rf binary   //删除软连接）
    [root@shaphicprc38250 VCN_R19C30]# rm -rf Uploads/  //删除文件夹）
    [root@shaphicprc38250 build]#
    [root@shaphicprc38250 build]# sh build.sh 
    invalid paraments: build.sh 
    Usage: build.sh [compiler] [product] [component] [version]
    The options are:
    Compiler: {x86 arm}
    Product: {cloud_center cloud_edge}
    Component: {all dcg_adapter_bocong dcg_adapter_congwen dcg_adapter_dahua dcg_adapter_hikvision dcg_adapter_vsp dcg_adapter_honeywell dcg_adapter_huawei dcg_adapter_ifaas dcg_adapter_infinova dcg_adapter_kedacom dcg_adapter_onvif dcg_adapter_t28181 dcg_adapter_teyes dcg_adapter_sdkset dcg_adapter_axis}
    Example:
        ./build.sh x86 cloud_edge all 1.19.20.000
    [root@shaphicprc38250 build]# sh build.sh x86 cloud_edge dcg_adapter_dahua 1.19.50.00
    [root@shaphicprc38250 build]# sh build.sh x86 cloud_edge dcg_adapter_hikvision 1.19.50.00

版本号修改



commit信息中包含的构建参数如下： build:dcg compile 

build:dcg_euler_edge_x86;dcg_new_euler_edge_x86;dcg_new_euler_edge_hw 

避免触发其他模块不必要的构建



C50构建签名

http://ivs.ci.package.trustworthiness.huawei.com:8080/job/IVS_VCN_R19C50_CMC_Version_Plugin_Pipeline/ 

登录后 一键出包



C20构建

构建地址

http://ivs.ci.package.trustworthiness.huawei.com:8080/job/IVS_VCN_R19C20_Version_Plugin_Pipeline/



vcm,zip构建签名

http://ivs.ci.package.trustworthiness.huawei.com:8080/job/IVS_VCM_Version_Manual_Signature_Pipeline/ 

待签名包放置路径： \\100.107.189.154\sign 出包地址\\10.184.162.238\Distribute\CloudVCM_V100R019C50_sign\IVS-V100R019C50\   （对应build ID目录下） 

samba服务

将编译服务器个人文件夹映射到本地win10

具体参见下列文件

需编辑 vim /etc/samba/smb.conf

http://3ms.huawei.com/km/blogs/details/5560395 

wecode常用操作

http://3ms.huawei.com/km/blogs/details/6423579#301 

分支命名规则

http://3ms.huawei.com/hi/group/2028923/wiki_5593540.html 

dump文件

dump文件在docker的如下目录，需在docker中安装gdb才能调试。

/var/log/coredump 

剥离出包

因摄像头授权问题，对应摄像头的SDK包需要用户自行安装，在出包时需将厂家的SDK包剥离

剥离方法如下：



，非剥离出包

MR注意事项



开发流程

1. 先从featureC50/dcg_spc300分支拉取个人分支 
2. 根据问题单或开发需求在个人分支修改代码，编包阶段自验 
3. 自验通过后没问题，将代码合入featureC50/dcg_spc300（主干分支），提merge的时候，需要SR需求单号，或者DTS问题单号。 
4. 基于featureC50/dcg_spc300（主干分支）出包自验修改点。各开发人员自己验证自己的功能点。功能正常后走问题单转测。  

问题单处理流程

1. DTS系统：https://dts.huawei.com/net/dts/Default.aspx。 
2. 找开发人员定位问题过程中，双发确认是开发人员问题，测试人员在DTS系统提单 
3. 基本流程：测试人员发现问题提单-》开发人员定位-》开发经理审核（王伯泉）-》开发人员实施修改-》开发经理审核（王伯泉）-》测试经理组织测试（苟彦）-》测试回归。 

IVS测试开发环境

C50SPC200集群环境

csp：https://51.34.67.71:31943/ [admin/Huawei@123]

客户端： 51.34.36.30 admin/Huawei12#$ dcgtest/Huawei12#$ 

后台地址： 51.34.67.70 登录账号[cspexpert/mt2017@cspos@RD]  登录后切换[root/cnp200@cspos@RD]

开发用C50SPC200单机x86环境

IBMC账号：8.44.97.126 [Administrator/Admin@9000]

csp：https://51.34.65.153:31943  [admin/Huawei@123]

客户端： 51.34.33.152 [admin/Huawei@123]  dcgtest/Huawei@123

后台地址： 51.34.65.152 账号[cspexpert/mt2017@cspos@RD]  登录后切换 [root/cnp200@cspos@RD] 

X86服务器(开发用) C50SPC200

IBMC账号： 8.44.96.99 [Administrator/Huawei@9000]

单机环境 csp：https://51.34.67.105:31943 [admin/Huawei@123]

客户端： 51.34.36.85 [admin/Huawei@123]

后台地址： 51.34.67.104 [admin/Huawei@123] 账号[cspexpert/mt2017@cspos@RD]  登录后切换 [root/cnp200@cspos@RD] 

单机x86  C50SPC200

IBMC账号： 8.44.96.98 [Administrator/Huawei@9000] BIOS：[Admin@9000]

服务器单机环境 csp：https://51.34.67.107:31943 admin/Huawei@123

客户端： 51.34.36.90 admin/Huawei@123

后台地址： 51.34.67.106 账号[cspexpert/mt2017@cspos@RD]  登录后切换 [root/cnp200@cspos@RD]  

C50SPC200 ARM单机环境

IBMC 账号 8.44.96.87  Administrator/Admin@9000

csp：https://51.34.67.91:31943  admin/Huawei@123

客户端：51.34.36.50 admin/Huawei@123

后台地址：51.34.67.90 admin/Huawei@123

登录账号cspexpert/mt2017@cspos@RD

登录后切换root/cnp200@cspos@RD

温度摄像机环境：51.34.33.6 admin/Huawei12#$

C20环境

iBMC：8.44.114.34   [Administrator/Admin@9000]

csp：https://51.34.67.111:31943 admin/Huawei@123

cu:51.34.36.100  admin/super123 

后台:51.34.67.110 [cspexpert/mt2017@cspos@RD]登录后切换 [root/cnp200@cspos@RD] 

大华摄像机：51.34.33.179 admin/admin123

相机信息

51.34.33.7/8/9/10/11 admin/Huawei12#$ 海康相机

可见光和热成像 2目像机 51.34.33.7  型号：DS-2TD1217-6/PA 

球机  51.34.33.8 型号：iDS-2DF8440IXS-A/SP/JM/T2 

四目像机 51.34.33.9  型号：DS-2CD6D24FWD-IZ

球机+筒机 51.34.33.10  型号：iDS-2SK8144IXS-D/J/JM/T2 

半球机  51.34.33.11 型号：iDS-2PT9144MX-D/T2

51.34.33.17 /178 admin/Huawei@123 大华相机

iClient配置摄像头

人脸属性配置，没有配置不会启动dahuastream的应用





包管理平台，手册下载

https://cmc-szv.clouddragon.huawei.com/cmcversion/index/search?searchKey=V100R019C50SPC200

测试华为包下载



设置VPN



访问csp添加代理例外设置





git常用操作

clone仓库

- git clone git@rnd-isourceb.huawei.com:ywx948591/utmaster.git utmaster
- git clone -b <branch> <remote_repo>- - # clone某个分支

 从远程仓库更新并合并到当前分支

- git pull # 从远程仓库获取最新数据到本地仓库，然后与当前分支合并

查看、添加、提交、删除、找回，重置修改文件

- git help <command> # 显示command的help
- git show # 显示某次提交的内容
- git show $id
- git checkout -- <file> # 抛弃工作文件修改
- git checkout . # 抛弃工作区修改
- git add <file> # 将工作文件修改提交到本地暂存区
- git add . # 将所有修改过的工作文件提交暂存区
- git rm <file> # 从版本库中删除文件
- git rm <file> --cached # 从版本库中删除文件，但不删除文件
- git reset <file> # 从暂存区恢复到工作文件
- git reset -- . # 从暂存区恢复到工作文件
- git reset --hard # 恢复最近一次提交过的状态，即放弃上次提交后的所有本次修改
- git commit <file> git commit . git commit -a # 将git add, git rm和git ci等操作都合并在一起做
- git commit -am  "some comments" git commit --amend # 修改最后一次提交记录
- 恢复某次提交的状态，恢复动作本身也创建了一次提交对象
- git revert HEAD # 恢复最后一次提交的状态

查看文件diff

- git diff <file> # 比较当前文件和暂存区文件差异
- git diff git diff <$id1> <$id2> # 比较两次提交之间的差异
- git diff <branch1>..<branch2> # 在两个分支之间比较
  git diff personalC50/ywx948591/lf_fjdc origin/featureC50/dcg_spc300  #多人开发比较分支版本与源版本差异
- git diff --staged # 比较暂存区和版本库差异
- git diff --cached # 比较暂存区和版本库差异
- git diff --stat # 仅仅比较统计信息

查看提交记录

- git log <file> # 查看该文件每次提交记录
- git log -p <file> # 查看每次详细修改内容的diff
- git log -p -2 # 查看最近两次详细修改内容的diff
- git log --stat # 查看提交统计信息

Git 本地分支管理

查看、切换、创建和删除分支

- git branch -r # 查看远程分支
- git branch <new_branch> # 创建新的分支
- git branch -v # 查看各个分支最后提交信息
- git branch --merged # 查看已经被合并到当前分支的分支
- git branch --no-merged # 查看尚未被合并到当前分支的分支
- git checkout <branch> # 切换到某个分支
- git checkout -b <new_branch> # 创建新的分支，并且切换过去
- git checkout -b <new_branch> <branch> # 基于branch创建新的new_branch
  git checkout -b personalC50/ywx948591/tjgz origin/personalC50/ywx948591/tjgz
- git checkout $id # 把某次历史提交记录checkout出来，但无分支信息，切换到其他分支会自动删除
- git checkout $id -b <new_branch> # 把某次历史提交记录checkout出来，创建成一个分支
- git branch -d <branch> # 删除某个分支
- git branch -D <branch> # 强制删除某个分支 (未被合并的分支被删除的时候需要强制)
- git branch -a --contains 013fbd4 #查找某个commit id在哪些分支里面

分支合并和rebase

- git merge <branch> # 将branch分支合并到当前分支
  git merge origin/featureC50/dcg_spc300	#将源分支的修改合并到本地分支
- git merge origin/master --no-ff # 不要Fast-Foward合并，这样可以生成merge提交
- git rebase master <branch> # 将master rebase到branch，相当于： git commit <branch> && git rebase master && git commit master && git merge <branch>

 Git补丁管理(方便在多台机器上开发同步时用)

- git diff > ../sync.patch # 生成补丁
- git apply ../sync.patch # 打补丁
- git apply --check ../sync.patch # 测试补丁能否成功

 Git暂存管理

- git stash # 暂存
- git stash list # 列所有stash
- git stash apply # 恢复暂存的内容
- git stash drop # 删除暂存区

 Git远程分支管理

- git pull # 抓取远程仓库所有分支更新并合并到本地
- git pull --no-ff # 抓取远程仓库所有分支更新并合并到本地，不要快进合并
- git fetch origin # 抓取远程仓库更新
- git merge origin/master # 将远程主分支合并到本地当前分支
- git commit --track origin/branch # 跟踪某个远程分支创建相应的本地分支
- git commit -b <local_branch> origin/<remote_branch> # 基于远程分支创建本地分支，功能同上
- git remote prune origin # 清理分支引用信息
- git remote prune origin git push # push所有分支
- git push origin master # 将本地主分支推到远程主分支
- git push -u origin master # 将本地主分支推到远程(如无远程主分支则创建，用于初始化远程仓库)
- git push origin <local_branch> # 创建远程分支， origin是远程仓库名
- git push origin <local_branch>:<remote_branch> # 创建远程分支
- git push origin :<remote_branch> #先删除本地分支(git br -d <branch>)，然后再push删除远程分支

 Git远程仓库管理

- git remote -v # 查看远程服务器地址和仓库名称
- git remote show origin # 查看远程服务器仓库状态
- git remote add origin git@github:robbin/robbin_site.git # 添加远程仓库地址
- git remote set-url origin git@github.com:robbin/robbin_site.git # 设置远程仓库地址(用于修改远程仓库地址)
- git remote rm <repository> # 删除远程仓库

清理本地垃圾文件

- git clean -f -d -x -n # 查看不在库里面的文件和文件夹
- git clean -f -d -x # 真正删除不在库里面的文件

 创建远程仓库

- git clone --bare robbin_site robbin_site.git # 用带版本的项目创建纯版本仓库
- scp -r my_project.git git@git.csdn.net:~ # 将纯仓库上传到服务器上
- mkdir robbin_site.git && cd robbin_site.git && git —bare init # 在服务器创建纯仓库
- git remote add origin git@github.com:robbin/robbin_site.git # 设置远程仓库地址
- git push -u origin master # 客户端首次提交
- git push -u origin develop # 首次将本地develop分支提交到远程develop分支，并且track
- git remote set-head origin master # 设置远程仓库的HEAD指向master分支

 命令设置跟踪远程库和本地库

- git branch --set-upstream master origin/master
- git branch --set-upstream develop origin/develop-

 tag管理

- git fetch origin +refs/tags/:refs/tags/ # 远程库的tag强制覆盖本地的
- git fetch --tags -v origin



scp

将windows下文件上传到服务器51.34.65.152

要cspexpert，root用户传不了 传到/home/cspexpert/以外目录需要权限

    #文件从本地复制到远程
    $ scp ivs_imgu.tar.gz cspexpert@51.34.65.152:/home/cspexpert/
    #文件夹从本地复制到远程 
    $ scp music/ cspexpert@51.34.65.152:/home/cspexpert/music/
    
    #文件从远程复制到本地   如果拷贝没权限，需在服务器行chmod 775 0722.tar.g
    $ scp -r cspexpert@51.34.65.152:/home/cspexpert/0722.tar.gz /d/Download/Chrome 
    #文件夹从远程复制到本地   
    $ scp -root@192.168.0.1:/home/root/others/ /home/space/music/



代码逻辑

代码的框架结构

- DCG_New，主进程，负责与平台交互。DCG，插件进程，与摄像头设备交互，

1400在dcg_new，老插件在dcg中，新插件在dcg_new中





每个机器最多能装6个mpu,端口紧张，mu,mgu 端口消耗大户，bmu，端口矩阵，

定时任务回收端口









原理大纲

信令，媒体通道分开





代码的数据量逻辑

重要类常用类 类图,时序图

设备上线

DCG_New管理插件管理



设备上线状态



添加主设备











元数据

元数据是：

    ●数据的数据

    ●结构化的数据

    ●用于描述数据的内容（what）、覆盖范围质量（where、when）、管理方式、数据的所有者（who）、数据的提供方式（how）等信息，是数据与数据用户之间的桥梁；

    ●资源的信息

    ●编目信息

    ●管理、控制信息

    ●是一组独立的关于资源的说明

    ● Data that defines and describes other data 

      传统的书目数据、产品目录、人事档案等都是元数据。元数据可以为各种形态的信息资源提供规范、普遍的描述方法和检索工具，为分布的、由多种资源组成的信息体系提供整合的工具与纽带，假设书是数据，那么离开书目目录的图书馆将成为一盘散沙，无法为用户提供有效的查找和相关的处理。

元数据与数据之间的关系：

      元数据也是数据，其本身也可以作为被描述对象，或者说是用于提供某种资源的有关信息的结构数据。

上述内容可概括为：元数据是描述数据的一种数据，为数据提供描述方法和检索工具



主进程

dcg_service

插件进程

Dcg_adapter_XXXXX



DCG_New

media_channel

业务流程

csp是干什么的：华为云服务管理平台，管理DCG平台的docker运行，插件加载升级

HoloSens iClient: 用户使用视频平台，业务功能配置实现。



DCG 视频平台的摄像头接入模块。在边缘云中以插件形式运行在docker中，在中心云环境运行在虚拟机中，本次的业务代码也是修改该模块代码。

业务代码知识wiki

问题处理

DCG插件进程杀掉后，主进程DCG_New会自己启动插件进程

wecode 工程依赖问题

imgu升级

停止scp的故障迁移和负载均衡



进容器脚本 ./login_new.sh mpu 

1. 脚本放入 /home/cspexpert/
2. chmod 777 login_new.sh
3. 运行  ./login_new.sh mpu
4. 输入对应的序号
5. 进入容器后，cd /home/ivs_imgu/lib/app/
   cp libimgu_storage.so libimgu_storage.so.bak
6. 停止imgu进程。 /home/ivstool/bin/service.sh stop imgu 
   . 退出容器，拷贝放在容器外的库  docker cp /home/cspexpert/libimgu_storage.so 容器	            ID:/home/ivs_imgu/lib/app; 
7. 重新进入容器，cd /home/ivs_imgu/lib/app  
8. chown ivsmu:ivs libimgu_storage.so;
   chmod 550 libimgu_storage.so;
9. 重启imgu.   /home/ivstool/bin/service.sh start imgu;
10. ps -ef|grep imgu 

ivsDemo使用

获取TLV需要用tools版本



获取TLV值

 

debug日志开关配置

    cd /home/ivs_dcg/plugins/dhsdk_1.19.50.000/config
    cd /home/ivs_dcg/plugins/hiksdk_1.19.50.001/config







docker ps  | grep mpu  (查看MPU容器的名称及进程号)

ps -ef | grep dcg   （查看DCG进程，其他以此类推）

docker exec -it 292(启动容器的名称) bash   (启动容器交互式界面)

cat /home/ivs_dcg/plugins/hiksdk_1..19.50.001(海康SDK插件)/config/ivs_dcg.config | grep {键入查询值}



docker查看日志操作

1. 登录具体操作系统
2. 切换用户到root—docker只能在root权限下操作(可通过whoami查看当前用户)；
3. 根据已知查找问题所在容器，查找对应的容器信息；
   上图中，命令docker images | grep mpu，是查看当前带mpu关键字的docker镜像信息。（静态未运行状态）

命令docker  ps | grep mpu，是查看带mpu关键字的docker容器信息（已经运行状态）。

其中，上图第一列为容器ID。后面进入容器操作都可以根据这个ID进行。

1. 根据具体的容器ID进入容器，命令为：

    docker exec -it 2f3708a0725b bash

其中，docker exec –it 2f3708a0725b 表示附着到容器2f3708a0725b，bash 表示通过Linux bash shell方式进行交互操作。

查找所有日志文件中是否包含CLIENT_RealLoadPictureEx字符串

    /Log/vcn/ivs_dcg/plugins/hiksdk_1.19.50.001/run
    /Log/vcn/ivs_dcg/plugins/dhsdk_1.19.50.001/run
    find ./ -name "*.log" | xargs grep -n "CLIENT_RealLoadPictureEx"
    find /etc -name '*httpd*'　
    
    #将日志文件中去掉MediaQueue.dequeue_head failed重新输出为run.log
    find ./ -name "*.log" | xargs grep -nv "MediaQueue.dequeue_head failed" > run.log
    #将日志文件中dcg_dahua_stream找出重新输出为run.log
    find ./ -name "*.log" | xargs grep -n "dcg_dahua_stream" > debug.log



1. 进入到日志目录(这里需要根据具体的信息定位日志目录)，我这里目前是定位到：
       /
   更新日志 
       :!e
   ctrl+f 后翻页，ctrl+b 前翻页，shift+g 到日志结尾
   vi 进入log日志
   GG  第一行     从上往下搜索关键字   /加搜索关键字
   shift+G  最底行   从下往上搜索关键字   ?加搜索关键字
   只打印最后500行
   tailf VA#gpu0_run_.log -n 500
   截取日志，并保存到ts.log中
   tailf VA#gpu0_run_.log |tee ts.log
   grep命令按照关键字抓包
   grep –rin “关键字” VA#gpu0_run_.log
2. 现在根据具体的错误相关信息定位问题

比如，我这里使用了TranID 、问题产生的时间、打印日志可能出现的Error关键字。

 

从docker中拷贝出文件

docker cp 60fa953e23d0:/Log/0722.pcap /home/cspexpert

将文件拷入docker

 docker cp /home/cspexpert/libimgu_storage.so 容器ID:/home/ivs_imgu/lib/app; 

海康SDK日志

日志路径：/Log/vcn/ivs_dcg/log/hiksdk/ 

日志开关配置路径 /home/ivs_dcg/plugins/3rd_config/hiksdk_1.19.50.021/config 

ivs_dcg.conf 

DCG_HIKSDK_LOG_SWITCH=1 

解析TLV

收集要tool里面的ivsdemo，版本不同可能没有。

 ./lua.exe TLVParser.lua 20200801112220000_0.tlv



代码编写，测试，编译，提交 ，发包流程

 iSource  使用

TCPDump

tcpdump安装抓包

1. 将test_all.zip  放入 /home/cspexpert, 解压
2. 进入test_all文件夹下，执行：chmod 777 *
3. 执行./deploy_x86.sh  (x86平台) 或者 ./deploy_arm.sh(arm平台)
4. 收集对应摄像头的网络包
   tcpdump -i any -s 0 -vvv -w wireshare.pcap //抓所有包
   tcpdump -i any -s0 -w baowen.pcap -v host 摄像机IP 

wirrshark分析

mu至cu的rtsp包

tcp[22:2]==9500

tcp contains "rect"报文中包含rect字符的

大华人脸坐标数据 tcp contains "BoundingBox"

- WeCode 使用 
  - 远程调试
- wecode 编写markdown文件

问题记录

解压缩

tar –cvf jpg.tar *.jpg //将目录里所有jpg文件打包成tar.jpg 

tar –czf jpg.tar.gz *.jpg //将目录里所有jpg文件打包成jpg.tar后，并且将其用gzip压缩，生成一个gzip压缩过的包，命名为jpg.tar.gz 

tar –cjf jpg.tar.bz2 *.jpg //将目录里所有jpg文件打包成jpg.tar后，并且将其用bzip2压缩，生成一个bzip2压缩过的包，命名为jpg.tar.bz2 

tar –cZf jpg.tar.Z *.jpg //将目录里所有jpg文件打包成jpg.tar后，并且将其用compress压缩，生成一个umcompress压缩过的包，命名为jpg.tar.Z 

rar a jpg.rar *.jpg //rar格式的压缩，需要先下载rar for linux 

zip jpg.zip *.jpg //zip格式的压缩，需要先下载zip for linux

tar –xvf file.tar //解压 tar包 

tar -xzvf file.tar.gz //解压tar.gz 

tar -xjvf file.tar.bz2 //解压 tar.bz2 

tar –xZvf file.tar.Z //解压tar.Z 

unrar e file.rar //解压rar 

unzip file.zip //解压zip 

日志文件说明

/var/log/message  系统启动后的信息和错误日志，是Red Hat Linux中最常用的日志之一 

/var/log/secure      与安全相关的日志信息 

/var/log/maillog    与邮件相关的日志信息 

/var/log/cron  与定时任务相关的日志信息 

/var/log/spooler    与UUCP和news设备相关的日志信息 

/var/log/boot.log  守护进程启动和停止相关的日志消息 

- 系统： 

# uname -a   # 查看内核/操作系统/CPU信息 

# cat /etc/issue  # 查看操作系统版本

# cat /etc/redhat-release # 查看操作系统版本 

# cat /proc/cpuinfo  # 查看CPU信息 

# hostname   # 查看计算机名 

# lspci -tv   # 列出所有PCI设备 

# lsusb -tv   # 列出所有USB设备 

# lsmod    # 列出加载的内核模块 

# env    # 查看环境变量 

资源： 

# free -m   # 查看内存使用量和交换区使用量 

# df -h    # 查看各分区使用情况 

# du -sh <目录名>  # 查看指定目录的大小 

# grep MemTotal /proc/meminfo # 查看内存总量 

# grep MemFree /proc/meminfo # 查看空闲内存量 

# uptime   # 查看系统运行时间、用户数、负载 

# cat /proc/loadavg  # 查看系统负载 

磁盘和分区： 

# mount | column -t  # 查看挂接的分区状态 

# fdisk -l   # 查看所有分区 

# swapon -s   # 查看所有交换分区 

# hdparm -i /dev/hda  # 查看磁盘参数(仅适用于IDE设备) 

# dmesg | grep IDE  # 查看启动时IDE设备检测状况 

网络： 

# ifconfig   # 查看所有网络接口的属性 

# iptables -L   # 查看防火墙设置 

# route -n   # 查看路由表 

# netstat -lntp   # 查看所有监听端口 

# netstat -antp   # 查看所有已经建立的连接 

# netstat -s   # 查看网络统计信息 

进程： 

# ps -ef   # 查看所有进程 

# top    # 实时显示进程状态（另一篇文章里面有详细的介绍） 

用户： 

# w    # 查看活动用户 

# id <用户名>   # 查看指定用户信息 

# last    # 查看用户登录日志 

# cut -d: -f1 /etc/passwd # 查看系统所有用户 

# cut -d: -f1 /etc/group # 查看系统所有组 

# crontab -l   # 查看当前用户的计划任务 

服务： 

# chkconfig –list  # 列出所有系统服务 

# chkconfig –list | grep on # 列出所有启动的系统服务 

程序： 

# rpm -qa   # 查看所有安装的软件包 




