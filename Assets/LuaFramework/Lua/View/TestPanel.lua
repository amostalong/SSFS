local transform;
local gameObject;

TestPanel = {};
local this = TestPanel;

--启动事件--
function TestPanel.Awake(obj)
	gameObject = obj;
	transform = obj.transform;

	this.InitPanel();
	logWarn("Awake lua--->>"..gameObject.name);
end

--初始化面板--
function TestPanel.InitPanel()
	UpdateBeat.Add(TestPanel.Update, this)
end

function TestPanel.Update()
	transform.Rotation(1,0,0)
end

--单击事件--
function TestPanel.OnDestroy()
	logWarn("OnDestroy---->>>");
end