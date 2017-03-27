'use strict';

function solve() {
	
	return function () {
		var template = `<h1>{{title}}</h1>
		<ul>
		{{#each posts}}
			<li>
				<div class="post">
					{{#if this.author}}
					<p class="author">
						<a class="user" href="/user/{{this.author}}">{{this.author}}</a>
					</p>
					{{/if}}
					{{#unless this.author}}
					<p class="author">
						<a class="anonymous">Anonymous</a>
					</p>
					{{/unless}}
					<pre class="content">{{{this.text}}}</pre>
				</div>
				{{#if comments.length}}
				<ul>
					{{#each this.comments}}
					{{#unless this.deleted}}
					<li>
						<div class="comment">
							{{#if this.author}}
							<p class="author">
								<a class="user" href="/user/{{this.author}}">{{this.author}}</a>
							</p>
							{{/if}}
							{{#unless this.author}}
							<p class="author">
								<a class="anonymous">Anonymous</a>
							</p>
							{{/unless}}
							<pre class="content">{{{this.text}}}</pre>
						</div>
					</li>
					{{/unless}}
					{{/each}}
				</ul>
				{{/if}}
			</li>
		{{/each}}
		</ul>`;

		return template;
	};
}

// submit the above

if (typeof module !== 'undefined') {
	module.exports = solve;
}
