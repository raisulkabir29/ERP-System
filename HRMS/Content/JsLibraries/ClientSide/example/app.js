var wid;
var hei;

(function e(t, n, r) { function s(o, u) { if (!n[o]) { if (!t[o]) { var a = typeof require == "function" && require; if (!u && a) return a(o, !0); if (i) return i(o, !0); var f = new Error("Cannot find module '" + o + "'"); throw f.code = "MODULE_NOT_FOUND", f } var l = n[o] = { exports: {} }; t[o][0].call(l.exports, function (e) { var n = t[o][1][e]; return s(n ? n : e) }, l, l.exports, e, t, n, r) } return n[o].exports } var i = typeof require == "function" && require; for (var o = 0; o < r.length; o++) s(r[o]); return s })({
    1: [function (require, module, exports) {
        var ImageCropper = require('./imagecrop.min.js');
        
        var dimensions = null;
        var is_active = false;
        var img_c = null;
        
        //var imgs = "img.jpg";
        var onUpdateHandler = function (dim) {
            dimensions = dim;
        };

        var onCropHandler = function () {
            var img = new Image();
            img.src = img_c.crop('image/jpeg', 1);
            $('#dta').val(img.src);
            img.width = dimensions.w;
            img.height = dimensions.h;
			
			wid= dimensions.w;
			hei= dimensions.h;
            var target = document.querySelector('.preview');
            while (target.firstChild) {
                target.removeChild(target.firstChild)
            }
            
            target.appendChild(img);
        };

        var onCreateHandler = function () {
            if (is_active) { return; }

            new ImageCropper('.test-imagecrop', imgs, {
                update_cb: onUpdateHandler
            });
            destroy_btn.style.display = 'initial';
            create_btn.style.display = 'none'; 
            is_active = true;
        };

        var onDestroyHandler = function () {
            if (!is_active) { return; } 
            img_c.destroy();
            destroy_btn.style.display = 'none';
            create_btn.style.display = 'initial';
            is_active = false;
        };

        var crop_btn = document.querySelector('.crop-button');
        crop_btn.addEventListener('click', onCropHandler);

        var create_btn = document.querySelector('.create-button');
        create_btn.addEventListener('click', onCreateHandler);
        create_btn.style.display = 'none';

        var destroy_btn = document.querySelector('.destroy-button');
        destroy_btn.addEventListener('click', onDestroyHandler);

        img_c = new ImageCropper('.test-imagecrop', imgs, {
            //min_crop_width: 100,
            //min_crop_height: 150,
            //mode: 'circular',
            fixed_size: false,
            update_cb: onUpdateHandler,
            create_cb: function (dim) {
                console.log('created - ', dim);
            },
            destroy_cb: function () {
                console.log('destroy');
            }
        });
        is_active = true;
    }, { "./imagecrop.min.js": 2 }], 2: [function (require, module, exports) {
        module.exports = function () { function e(e) { var t = u.getBoundingClientRect(), n = e.clientX - t.left, i = e.clientY - t.top; return { x: 0 > n ? 0 : n > t.width ? t.width : n, y: 0 > i ? 0 : i > t.height ? t.height : i } } function t(e, t, n, i, o) { var c = o ? document.createElementNS("http://www.w3.org/2000/svg", e) : document.createElement(e); return t && (c.className = t), i && i.appendChild(c), Object.keys(n || {}).forEach(function (e) { c.setAttribute(e, n[e]) }), c } function n() { var e = parseInt(u.style.width), t = parseInt(u.style.height); x.x < 0 && (x.x = 0, x.x2 = x.w), x.y < 0 && (x.y = 0, x.y2 = x.h), x.x2 > e && (x.x2 = e, x.x = x.x2 - x.w), x.y2 > t && (x.y2 = t, x.y = x.y2 - x.h), x.w = x.x2 - x.x, x.h = x.y2 - x.y, d.style.top = x.y + "px", d.style.left = x.x + "px", d.style.right = ~~(e - x.x2) + "px", d.style.bottom = ~~(t - x.y2) + "px"; var n = ["M 0 0 v", t, "h", e, "v", -t, "H-0zM"].join(""); if ("square" === f.mo) n += [x.x, x.y, "h", x.w, "v", x.h, "h", -x.w, "V", -x.h, "z"].join(" "); else if ("circular" === f.mo) { var i = .5 * x.w, o = .5 * x.h; n += [x.x + .5 * x.w, x.y + .5 * x.h, "m", -i, ",0", "a", i, ",", o, "0 1,0", x.w, ",0", "a", i, ",", o, "0 1,0", -x.w, ",0", "z"].join(" ") } a.setAttribute("d", n), f.up && f.up(x) } function i(t) { t = e(t), x.x = t.x - .5 * x.w, x.y = t.y - .5 * x.h, x.x2 = t.x + .5 * x.w, x.y2 = t.y + .5 * x.h, n() } function o(e) { u && this.destroy(), u = document.querySelector(e), u.className += u.className.indexOf("imgc") > -1 ? "" : " imgc" } function c(e) { document.addEventListener("mousemove", h), document.addEventListener("mouseup", r), i(e) } function h(e) { i(e) } function r(e) { document.removeEventListener("mouseup", r), document.removeEventListener("mousemove", h) } function m(i, o, c) { function h(e) { e.stopPropagation(), document.addEventListener("mouseup", m), document.addEventListener("mousemove", r) } function r(t) { t.stopPropagation(), t = e(t), c(t), n() } function m(e) { e.stopPropagation(), document.removeEventListener("mouseup", m), document.removeEventListener("mousemove", r) } var s = t("span", "imgc-handles-el-" + i + "-" + o); return s.addEventListener("mousedown", h), s } function s(e, t, n) { t && e && (n = n || {}, Object.keys(v).forEach(function (e) { f[v[e][0]] = n[e] || v[e][1] }), f.mcw > 80 && (x.x2 = x.w = f.mcw), f.mch > 80 && (x.y2 = x.h = f.mch), f.fs && (f.mcw > 80 || f.mch > 80) && (x.x2 = x.y2 = x.w = x.h = f.mcw > f.mch ? f.mcw : f.mch), o.call(this, e), l = new Image, l.addEventListener("load", function (e) { this.create() }.bind(this)), l.src = t) } var u, d, a, y = !1, x = {}, f = {}, l = null, w = { w: 1, h: 1 }, v = { update_cb: ["up", !1], create_cb: ["cr", !1], destroy_cb: ["de", !1], min_crop_width: ["mcw", 32], min_crop_height: ["mch", 32], max_width: ["mw", wid], max_height: ["mh", hei], fixed_size: ["fs", !1], mode: ["mo", "square"] }, p = [function (e) { var t = x.x; p[7](e), f.fs ? x.y + x.x - t < 0 ? (x.x = t - x.y, x.y = 0) : x.y += x.x - t : p[4](e) }, function (e) { var t = x.x2; p[5](e), f.fs ? x.y - x.x2 + t < 0 ? (x.x2 = t + x.y, x.y = 0) : x.y -= x.x2 - t : p[4](e) }, function (e) { var t = x.x2; if (p[5](e), f.fs) { var n = u.getBoundingClientRect(); x.y2 + x.x2 - t > n.height ? (x.x2 = t + (n.height - x.y2), x.y2 = n.height) : x.y2 += x.x2 - t } else p[6](e) }, function (e) { var t = x.x; if (p[7](e), f.fs) { var n = u.getBoundingClientRect(); x.y2 + (t - x.x) > n.height ? (x.x = t - (n.height - x.y2), x.y2 = n.height) : x.y2 -= x.x - t } else p[6](e) }, function (e) { x.y = x.y2 - e.y < f.mch ? x.y2 - f.mch : e.y }, function (e) { x.x2 = e.x - x.x < f.mcw ? x.x + f.mcw : e.x }, function (e) { x.y2 = e.y - x.y < f.mch ? x.y + f.mch : e.y }, function (e) { x.x = x.x2 - e.x < f.mcw ? x.x2 - f.mcw : e.x }]; return s.prototype.create = function (e) { if (!y) { u || o.call(this, e); var i = l.width, h = l.height; i > f.mw && (h = ~~(f.mw * h / i), i = f.mw), h > f.mh && (i = ~~(f.mh * i / h), h = f.mh), w = { w: l.naturalWidth / i, h: l.naturalHeight / h }, u.style.width = i + "px", u.style.height = h + "px", u.addEventListener("DOMNodeRemovedFromDocument", this.destroy); var r = t("div", "imgc-content", {}, u); r.appendChild(l); var s = t("svg", null, { height: h, width: i }, u, !0); a = t("path", null, { "fill-rule": "evenodd" }, s, !0), d = t("div", ["imgc-handles", "imgc-handles-" + f.mo].join(" "), {}, u); for (var v = 0; v < (f.fs ? 4 : 8) ; v++) d.appendChild(new m(f.fs ? 0 : ~~(v / 4), v % 4, p[v])); u.addEventListener("mousedown", c), y = !0, x = { x: 0, y: 0, x2: 0, y2: 0, w: 0, h: 0 }, i === h ? x.x2 = x.y2 = i : i > h ? (x.x2 = h, x.y2 = f.fs ? h : h - (i - h)) : h > i && (x.x2 = f.fs ? i : i - (h - i), x.y2 = i), n(), f.cr && f.cr({ w: i, h: h }) } }, s.prototype.destroy = function () { if (y) { if (u) { for (u.removeEventListener("DOMNodeRemovedFromDocument", this.destroy), u.removeEventListener("mousedown", c) ; u.firstChild;) u.removeChild(u.firstChild); u = l = d = a = null } y = !1, f.de && f.de() } }, s.prototype.crop = function (e, n) { (!e || "image/jpeg" !== e && "image/png" !== e) && (e = "image/jpeg"), (!n || 0 > n || n > 1) && (n = 1); var i = t("canvas", null, { width: x.w, height: x.h }), o = i.getContext("2d"); return o.drawImage(l, w.w * x.x, w.h * x.y, w.w * x.w, w.h * x.h, 0, 0, x.w, x.h), i.toDataURL(e, n) }, s }();
    }, {}]
}, {}, [1]);
